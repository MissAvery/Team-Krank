using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootTree : MonoBehaviour
{
    GameObject[] GlobalBasicBalancing;
    BasicBalacing balancing;
    [SerializeField] HealthBar healthBar;

    private void OnTriggerEnter2D(Collider2D other) {
        //if(other enemyType1)...

        balancing.rootHealthPoints -= 1;
        healthBar.SetHealth(balancing.rootHealthPoints);

        // Alles weitere
        Destroy(other.gameObject);

        if(balancing.rootHealthPoints <= 0) {
            // Animation, effekte, etc
            balancing.gameOver = true;
            balancing.buildEnabled = false;

            // Placeholder
            Debug.Log("GAME OVER");
            //this.gameObject.SetActive(false);
            //Time.timeScale = 0.1f;


        }
    }

    private void Awake() {
        GlobalBasicBalancing = GameObject.FindGameObjectsWithTag("GlobalBalancing");
        balancing = GlobalBasicBalancing[0].GetComponent<BasicBalacing>();
        healthBar.SetMaxHealth(balancing.rootHealthPoints);
    }
}
