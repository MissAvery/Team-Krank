using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    [SerializeField]
    private Transform[] pathpoints;

    [SerializeField]
    private float walkSpeed;

    private int pathpointIndex = 0;

    private void Start (){
        transform.position = pathpoints[pathpointIndex].transform.position;
    }

    private void Update (){
        walki();
    }

    public void walki(){

        if (pathpointIndex <= pathpoints.Length - 1){

             transform.position = Vector2.MoveTowards(transform.position, pathpoints[pathpointIndex].transform.position, walkSpeed * Time.deltaTime);

            if (transform.position == pathpoints[pathpointIndex].transform.position){

                pathpointIndex += 1;
            }
        }
    }
}
