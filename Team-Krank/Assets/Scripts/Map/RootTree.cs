using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootTree : MonoBehaviour
{
    GameObject[] GlobalBasicBalancing;
    BasicBalacing balancing;

    private void OnTriggerEnter2D(Collider2D other) {
        //if(other enemyType1)...

        balancing.rootHealthPoints -= 1;

        // Alles weitere
        Destroy(other.gameObject);

        if(balancing.rootHealthPoints <= 0) {
            // Animation, effekte, etc
            balancing.gameOver = true;
            balancing.buildEnabled = false;

            // Placeholder
            Debug.Log("GAME OVER");
            this.gameObject.SetActive(false);
            

            
        }
    }

    private void Awake() {
        GlobalBasicBalancing = GameObject.FindGameObjectsWithTag("GlobalBalancing");
        balancing = GlobalBasicBalancing[0].GetComponent<BasicBalacing>();
    }
}
