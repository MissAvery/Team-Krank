using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePrefabManager : MonoBehaviour
{

    [SerializeField] List<GameObject> scenePrefabs = new List<GameObject>();


    private void Awake() {
        spawnPrefab();
    }


    void spawnPrefab() {
        int i = 0;
        foreach(GameObject child in scenePrefabs) { 
            Instantiate(scenePrefabs[i]);
            i++;
        }
        
    }
}
