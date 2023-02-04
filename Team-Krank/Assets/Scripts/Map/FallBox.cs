using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallBox : MonoBehaviour
{

    private void OnTriggerEnter(Collider other) {
        MovementPlaceholder enemy = other.GetComponent<MovementPlaceholder>();
        if (enemy.thisIsUnit) {
            enemy.falling = true;
        }
    }
    private void OnTriggerExit(Collider other) {
        MovementPlaceholder movement = other.GetComponent<MovementPlaceholder>();
        if (movement.thisIsUnit) {
            movement.falling = false;


            if (movement.movementSwitched) { other.GetComponent<MovementPlaceholder>().movementSwitched = false; }
            else if (!movement.movementSwitched) { other.GetComponent<MovementPlaceholder>().movementSwitched = true; }
        }
    }
}
