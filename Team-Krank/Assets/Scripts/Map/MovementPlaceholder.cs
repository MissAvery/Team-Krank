using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlaceholder : MonoBehaviour
{

    GameObject[] GlobalBasicBalancing;
    BasicBalacing balancing;
    Collider col;
    public bool thisIsUnit = true;
    float localEnemySpeed;
    public bool movementSwitched = false;
    public bool falling = false;
    public bool slowed = false;


    public void FixedUpdate() {
     movementStep();
    }

    //Discard
    public void movementStep() {
        Vector2 newPosition = transform.position;
        Vector3 newTransfom = transform.localScale;
        if (!falling) {
            if (!movementSwitched) {
                newPosition.x += localEnemySpeed;
            }
            else {
                newPosition.x -= localEnemySpeed;
            } 
            transform.position = newPosition;
        }
        else {
            newPosition.y -= balancing.fallSpeed/100;
            transform.position = newPosition;
        }
    }

    //Übernehmen!
    public void mirrorSprite(bool state) {
        Vector3 newTransfom = transform.localScale;

        if (state) {
            newTransfom += new Vector3(2, 0, 0);
        }
        else if (!state) {
            newTransfom -= new Vector3(-2, 0, 0);
        }
        transform.localScale = newTransfom;
    }

    private void Awake() {
        GlobalBasicBalancing = GameObject.FindGameObjectsWithTag("GlobalBalancing");
        balancing = GlobalBasicBalancing[0].GetComponent<BasicBalacing>();
        localEnemySpeed = balancing.enemySpeed[0]/100;
    }

}

