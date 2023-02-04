using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawn : MonoBehaviour {
    GameObject[] GlobalBasicBalancing;
    BasicBalacing balancing;
    float localSpawntime;
    float localCooldown;
    int localMaxSpawnCount;



    int count = 1;




    void SpawnUnit() {
        Vector2 spawnPosition = this.transform.position;
        Quaternion spawnRotation = this.transform.rotation;
        GameObject currentEnemy = Instantiate(balancing.enemyTypes[balancing.enemyWaveType[balancing.waveCount]], spawnPosition, spawnRotation);
        balancing.enemiesAlive.Add(currentEnemy);
        currentEnemy = null;
    }



    private void Awake() {
        StartUp();
        StartCoroutine(SpawnInterval());

    }
    bool runOnce = false;
    int rnd;
    IEnumerator SpawnInterval() {
        while (true) {
            // OHNE RANDOM!
            if (!balancing.enableRandomAmount) {
                if (count <= /*localMaxSpawnCount*/ balancing.maxSpawnCount[balancing.waveCount]) {
                    SpawnUnit();
                    count++;
                    yield return new WaitForSeconds(localSpawntime);
                }
                else if (balancing.enemiesAlive.Count <= 0 && count >= /*localMaxSpawnCount*/ balancing.maxSpawnCount[balancing.waveCount]) {
                    count = 1;
                    yield return new WaitForSeconds(localCooldown);
                    balancing.waveCount = balancing.waveCount + 1;
                    balancing.buildEnabled = false;


                }
                else {
                    yield return new WaitForSeconds(localSpawntime);
                }
            }
            // MIT RANDOM!
            else if (balancing.enableRandomAmount) {

                if (!runOnce) {
                    rnd = Random.Range(balancing.minSpawnCount[balancing.waveCount], balancing.maxSpawnCount[balancing.waveCount]);
                    runOnce = true;
                }

                if (count <= rnd) {
                    SpawnUnit();
                    count++;
                    yield return new WaitForSeconds(localSpawntime);
                }
                else if (balancing.enemiesAlive.Count <= 0 && count >= rnd) {
                    count = 1;
                    yield return new WaitForSeconds(localCooldown);
                    balancing.waveCount = balancing.waveCount + 1;
                    balancing.buildEnabled = false;
                    runOnce = false;
                }
                else {
                    yield return new WaitForSeconds(localSpawntime);
                }
            }

        }
    }


    void checkIfWaveCleared() {
        if (balancing.enemiesAlive.Count <= 0) {
            balancing.buildEnabled = true;
        }
        //check Ob Gegner dod
        else {
            for (int i = 0; i < balancing.enemiesAlive.Count; i++) {
                if (balancing.enemiesAlive[i] == null) balancing.enemiesAlive.Remove(balancing.enemiesAlive[i]);
            }
        }
    }

    void Timer() {
        if (balancing.buildEnabled) {

            balancing.remainingTimeTillNextWave -= Time.deltaTime;

            //Debug.Log(timeRemaining);
        }
        else balancing.remainingTimeTillNextWave = balancing.roundCooldown;
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

        localSpawntime = balancing.spawnInbetweenTime;
        localCooldown = balancing.roundCooldown;
        balancing.remainingTimeTillNextWave = balancing.roundCooldown;
        localMaxSpawnCount = balancing.maxSpawnCount[balancing.waveCount];
    }

}
