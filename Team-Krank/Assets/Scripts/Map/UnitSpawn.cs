using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawn : MonoBehaviour
{
    [SerializeField] GameObject GlobalBasicBalancing;
    BasicBalacing balancing;
    float localSpawntime;

    int count = 0;



    private void Start() {

        balancing = GlobalBasicBalancing.GetComponent<BasicBalacing>();
        StartCoroutine(SpawnInterval());
    }

    void SpawnUnit() {
        Vector2 spawnPosition = this.transform.position;
        Quaternion spawnRotation = this.transform.rotation;
        Instantiate(balancing.enemyTypes[balancing.nextSpawnThisUnit], spawnPosition, spawnRotation);

        Debug.Log(count);
    }


    IEnumerator SpawnInterval() {
            while (true) {
            
            if (count <= balancing.maxSpawnCount) {
                SpawnUnit();
                count++;
                yield return new WaitForSeconds(balancing.spawnTime);
            }
            else {
                count = 0;
                yield return new WaitForSeconds(balancing.spawnCooldown);
            }
        }
    }

}
