using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBalacing : MonoBehaviour {
    [Header("Balancing")]
    public int rootHealthPoints = 20;
    public float spawnInbetweenTime = 1f;
    public float roundCooldown = 5f;
    //public int maxSpawnCount = 10;
    public List <int> maxSpawnCount = new List<int>();
    public bool enableRandomAmount = false;
    //public int minSpawnCount = 1;
    public List<int> minSpawnCount = new List<int>();
    public List<GameObject> enemyTypes = new List<GameObject>();
    public List<float> enemySpeed = new List<float>();
    public List<int> enemyWaveType = new List<int>();
    //Die Punkte m�ssen noch irgendwo eingebaut werden
    public int nextSpawnedUnitType = 0;
    public float fallSpeed = 2f;

    //public float slowFactor = 0.5f;






    [Header("Transmitted Variables")]
    public bool buildEnabled;
    public bool gameOver = false;
    public int waveCount = 0;

    [Header("Debug")]
    public List<GameObject> enemiesAlive = new List<GameObject>();
    public float remainingTimeTillNextWave;
    public int targetFrameRate;



    private void Start() {
        Application.targetFrameRate = targetFrameRate;
    }
}
