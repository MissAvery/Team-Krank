using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBalacing : MonoBehaviour
{
    public float spawnTime = 1f;
    public int maxSpawnCount = 10;
    public List<GameObject> enemyTypes = new List<GameObject>();
    public int nextSpawnThisUnit = 0;
    public float spawnCooldown = 5f;


}
