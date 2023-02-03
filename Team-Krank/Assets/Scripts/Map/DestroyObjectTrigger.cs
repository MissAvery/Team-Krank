using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectTrigger : MonoBehaviour
{
    public int healthPoints = 20;
    public bool GameOver = false;

    private void OnTriggerEnter(Collider other) {
        // HP abziehen
        //if(other enemyType1)...

        healthPoints -= 1;

        // Alles weitere
        Destroy(other.gameObject);

        if(healthPoints <= 0) {
            // Animation, effekte, etc
            GameOver = true;

            // Placeholder
            Debug.Log("GAME OVER");
            Destroy(this.gameObject);
            

            
        }
    }
}
