using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] GameObject destinationTeleport;

    private void OnTriggerEnter(Collider other) {
            //Debug.Log("collision: " + other);

            MovementPlaceholder enemy = other.gameObject.GetComponent<MovementPlaceholder>();
            if (enemy) {

                other.transform.position = destinationTeleport.transform.position;
 

                if (!enemy.movementSwitched) {
                enemy.movementSwitched = true;
                //enemy.mirrorSprite(true);
            }

                else {
                enemy.movementSwitched = false;
                //enemy.mirrorSprite(false);
            }


            }
    }
}
