using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBalacing : MonoBehaviour {
    [Header("Balancing")]
    public int rootHealthPoints = 20;
    public float spawnInbetweenTime = 1f;
    public float roundCooldown = 5f;
    public List <int> maxSpawnCount = new List<int>();
    public bool enableRandomAmount = false;
    public List<int> minSpawnCount = new List<int>();
    public List<GameObject> enemyTypes = new List<GameObject>();
    public List<int> enemyWaveType = new List<int>();

    public List<float> enemyStartHealth = new List<float>();
    public List<float> enemySpeed = new List<float>();
    //Die Punkte müssen noch irgendwo eingebaut werden
    public float fallSpeed = 2f;
    //public float slowFactor = 0.5f;
    public float pathCompletedThreshold;





    [Header("Transmitted Variables")]
    public bool buildEnabled;
    public bool gameOver = false;
    public int waveCount = 0;
    public List<GameObject> pathPoints = new List<GameObject>();

    [Header("Debug")]
    public List<GameObject> enemiesAlive = new List<GameObject>();
    public float remainingTimeTillNextWave;
    public int targetFrameRate;



    [SerializeField] GameObject pathParent;
    void AddPathPoints() {
        foreach (Transform child in pathParent.transform) {
            pathPoints.Add(child.gameObject);
        }
    }

    private void Awake() {
        Application.targetFrameRate = targetFrameRate;
        AddPathPoints();
    }
}
