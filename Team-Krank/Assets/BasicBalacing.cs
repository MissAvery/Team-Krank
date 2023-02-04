using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBalacing : MonoBehaviour
{
    public float spawnTimeBetween = 1f;
    public int maxSpawnCount = 10;
    public List<GameObject> enemyTypes = new List<GameObject>();
    public List<float> enemySpeed = new List<float>();
    public float fallSpeed = 2f;
    public int nextSpawnThisUnit = 0;
    public float spawnCooldown = 5f;
    public float slowFactor = 0.5f;
    public int rootHealthPoints = 20;
    public bool gameOver = false;


    public bool buildEnabled;



}
