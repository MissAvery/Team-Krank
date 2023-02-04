using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallBox : MonoBehaviour
{
    GameObject[] GlobalBasicBalancing;
    BasicBalacing balancing;

    private void OnTriggerEnter(Collider other) {
        MovementPlaceholder movement = other.GetComponent<MovementPlaceholder>();
        if (movement.thisIsUnit) {
            movement.falling = true;
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









    private void Awake() {
        GlobalBasicBalancing = GameObject.FindGameObjectsWithTag("GlobalBalancing");
        balancing = GlobalBasicBalancing[0].GetComponent<BasicBalacing>();
    }
}
