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

    int count = 1;




    void SpawnUnit() {
        Vector2 spawnPosition = this.transform.position;
        Quaternion spawnRotation = this.transform.rotation;
        Instantiate(balancing.enemyTypes[balancing.nextSpawnThisUnit], spawnPosition, spawnRotation);

        //Debug.Log(count);
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
            else {
                count = 0;
                yield return new WaitForSeconds(localCooldown);
            }
        }
    }

    void StartUp() {
        GlobalBasicBalancing = GameObject.FindGameObjectsWithTag("GlobalBalancing");
        balancing = GlobalBasicBalancing[0].GetComponent<BasicBalacing>();

        localSpawntime = balancing.spawnTime;
        localCooldown = balancing.spawnCooldown;
        localMaxSpawnCount = balancing.maxSpawnCount;
    }

}
