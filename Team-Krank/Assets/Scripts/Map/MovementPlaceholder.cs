using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlaceholder : MonoBehaviour
{
    public bool thisIsUnit = true;
    bool movementRestricted = false;
    public float stepDistance = 0.2f;
    public bool movementSwitched = false;

    [SerializeField] private bool debugActivateMovement = true;

    public void Update() {

        if (debugActivateMovement) movementStep();

    }

    void movementStep() {
        Vector2 newPosition = transform.position;
        if  (!movementSwitched) newPosition.x += stepDistance;
        else newPosition.x -= stepDistance;

        transform.position = newPosition;
    }




}
