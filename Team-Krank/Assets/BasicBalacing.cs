using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    //public float pathCompletedThreshold;
    // Outdated
    public bool useTeleportOrPath;



    [Header("Transmitted Variables")]
    public bool buildEnabled;
    public bool gameOver = false;
    public bool win = false;
    public int waveCount = 0;
    public List<GameObject> pathPoints = new List<GameObject>();

    [Header("Debug")]
    public List<GameObject> enemiesAlive = new List<GameObject>();
    public float remainingTimeTillNextWave;
    public bool activateWaitForPlayerInput = false;
    public int targetFrameRate;
    //public GameObject Timer;







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

    //private void Update() {
    //    if (buildEnabled) {
    //        Timer.SetActive(true);
    //        float seconds = Mathf.FloorToInt(remainingTimeTillNextWave % 60);
    //        Timer.GetComponent<Text>().text = seconds.ToString();

    //    }
    //    else { Timer.SetActive(false); }
    //}

}
