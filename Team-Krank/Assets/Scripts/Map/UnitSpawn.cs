using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawn : MonoBehaviour {
    GameObject[] GlobalBasicBalancing;
    BasicBalacing bal;
    float localSpawntime;
    float localCooldown;
    int localMaxSpawnCount;



    int count = 1;


    void SpawnUnit() {
        Vector2 spawnPosition = this.transform.position;
        Quaternion spawnRotation = this.transform.rotation;
        GameObject currentEnemy = Instantiate(bal.enemyTypes[bal.enemyWaveType[bal.waveCount]], spawnPosition, spawnRotation);
        bal.enemiesAlive.Add(currentEnemy);
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
            if (!bal.enableRandomAmount) {
                if (count <= bal.maxSpawnCount[bal.waveCount]) {
                    SpawnUnit();
                    count++;
                    yield return new WaitForSeconds(localSpawntime);
                }
                else if (bal.enemiesAlive.Count <= 0 && count >= bal.maxSpawnCount[bal.waveCount]) {
                    count = 1;
                    yield return new WaitForSeconds(localCooldown);
                    EnableTraps();

                }
                else {
                    yield return new WaitForSeconds(localSpawntime);
                }
            }
            // MIT RANDOM!
            else if (bal.enableRandomAmount) {

                if (!runOnce) {
                    rnd = Random.Range(bal.minSpawnCount[bal.waveCount], bal.maxSpawnCount[bal.waveCount]);
                    runOnce = true;
                }

                if (count <= rnd) {
                    SpawnUnit();
                    count++;
                    yield return new WaitForSeconds(localSpawntime);
                }
                else if (bal.enemiesAlive.Count <= 0 && count >= rnd) {
                    count = 1;
                    yield return new WaitForSeconds(localCooldown);
                    runOnce = false;
                    EnableTraps();

                }
                else {
                    yield return new WaitForSeconds(localSpawntime);
                }
            }

        }
    }

    void EnableTraps() {
        bal.waveCount = bal.waveCount + 1;
        bal.buildEnabled = false;

        foreach (GameObject trapP in GameObject.Find("TrapPointList").GetComponent<PointList>().points) {       //Enables Traps
            trapP.GetComponent<TrapPoint>().Setmode("InRound");
        }
    }

    void checkIfWaveCleared() {
        if (bal.enemiesAlive.Count <= 0) {
            bal.buildEnabled = true;

            foreach (GameObject trapP in GameObject.Find("TrapPointList").GetComponent<PointList>().points){            //Enables Trap-placement
                trapP.GetComponent<TrapPoint>().Setmode("BetweenRounds");
            }

        }
        //check Ob Gegner dod
        else {
            for (int i = 0; i < bal.enemiesAlive.Count; i++) {
                if (bal.enemiesAlive[i] == null) bal.enemiesAlive.Remove(bal.enemiesAlive[i]);
            }
        }
    }

    void Timer() {
        if (bal.buildEnabled) {

            bal.remainingTimeTillNextWave -= Time.deltaTime;

            //Debug.Log(timeRemaining);
        }
        else bal.remainingTimeTillNextWave = bal.roundCooldown;
    }

    private void Update() {
        Timer();

        if (bal.waveCount <= 4) {
            bal.win = true;
            StopCoroutine(SpawnInterval());
            //Time.timeScale = 0.01f;
        }
    }
    private void FixedUpdate() {
        checkIfWaveCleared();
    }


    void StartUp() {
        GlobalBasicBalancing = GameObject.FindGameObjectsWithTag("GlobalBalancing");
        bal = GlobalBasicBalancing[0].GetComponent<BasicBalacing>();

        localSpawntime = bal.spawnInbetweenTime;
        localCooldown = bal.roundCooldown;
        bal.remainingTimeTillNextWave = bal.roundCooldown;
        localMaxSpawnCount = bal.maxSpawnCount[bal.waveCount];

    }

}
