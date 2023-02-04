using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawn : MonoBehaviour
{
    GameObject[] GlobalBasicBalancing;
    BasicBalacing balancing;
    float localSpawntime;
    float localCooldown;
    int localMaxSpawnCount;
    public List<GameObject> enemiesAlive = new List<GameObject>();
    int amountOfActiveEnemies = 0;


    public float timeRemaining;
    int count = 1;




    void SpawnUnit() {
        Vector2 spawnPosition = this.transform.position;
        Quaternion spawnRotation = this.transform.rotation;
        GameObject currentEnemy = Instantiate(balancing.enemyTypes[balancing.nextSpawnThisUnit], spawnPosition, spawnRotation);
        enemiesAlive.Add(currentEnemy);
        currentEnemy = null;
        amountOfActiveEnemies += 1;
    }



    private void Awake() {
        StartUp();
        StartCoroutine(SpawnInterval());
    }

    IEnumerator SpawnInterval() {
            while (true) {

            if (count <= localMaxSpawnCount) {
                SpawnUnit();
                count++;
                yield return new WaitForSeconds(localSpawntime);
            }
            else if (enemiesAlive.Count <= 0 && count >= localMaxSpawnCount) {
                count = 1;
                yield return new WaitForSeconds(localCooldown);
                balancing.buildEnabled = false;
            }
            else {
                yield return new WaitForSeconds(localSpawntime);
                //Debug.Log("Waiting... " + enemiesAlive.Count);
            } 
                
        }
    }

    void checkIfWaveCleared() {
        if (enemiesAlive.Count <= 0) {
            balancing.buildEnabled = true;
        }
        //check Ob Gegner dod
        else {
            for (int i = 0; i < enemiesAlive.Count; i++) {
                if(enemiesAlive[i] == null) enemiesAlive.Remove(enemiesAlive[i]);
            }
        }
    }

    void Timer() {
        if (balancing.buildEnabled) {
           
            timeRemaining -=Time.deltaTime;

            //Debug.Log(timeRemaining);
        }
        else timeRemaining = balancing.spawnCooldown;
    }

    private void Update() {
        Timer();
    }
    private void FixedUpdate() {
        checkIfWaveCleared();
    }








    void StartUp() {
        GlobalBasicBalancing = GameObject.FindGameObjectsWithTag("GlobalBalancing");
        balancing = GlobalBasicBalancing[0].GetComponent<BasicBalacing>();

        localSpawntime = balancing.spawnTimeBetween;
        localCooldown = balancing.spawnCooldown;
        timeRemaining = balancing.spawnCooldown;
        localMaxSpawnCount = balancing.maxSpawnCount;
    }

}
