using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapPoint : MonoBehaviour
{
    private string mode;
    private bool used;
    private GameObject trap;

    public GameObject StrongRoot;
    public GameObject MultipleRoots;
    public GameObject WallRoot;
    public GameObject WeakeningRoot;
    public GameObject Trapdoor;
    public GameObject Spikes;
    
    public GameObject SlownessField;

    public Canvas trapUI;
    public Canvas button;
    void Start()
    {
        used = false;
        trapUI.enabled = false;
    }

   public void Clicked(){
    if(mode == "BetweenRounds"){
        if(!used){
            trapUI.enabled = true;
            used = true;
            button.enabled = false;
        }
    }
   }

   public void Setmode(string newMode){
        mode = newMode;
    }

    public void BuildTrap(string trapType){
        switch (trapType){
            case "Strong":
                trap = Instantiate(StrongRoot, transform.position, Quaternion.identity);
            break;
            case "Wall":
                trap = Instantiate(WallRoot, transform.position, Quaternion.identity);
            break;
            case "Multiple":
                trap = Instantiate(MultipleRoots, transform.position, Quaternion.identity);
            break;
            case "Weakening":
                trap = Instantiate(WeakeningRoot, transform.position, Quaternion.identity);
            break;
            case "Trapdoor":
                trap = Instantiate(Trapdoor, transform.position, Quaternion.identity);
            break;
            case "Spikes":
                trap = Instantiate(Spikes, transform.position, Quaternion.identity);
            break;
            case "Slowness":
                trap = Instantiate(SlownessField, transform.position, Quaternion.identity);
            break;
            }
            trap.GetComponent<Trap>().SetTrapPoint(gameObject);
            trapUI.enabled = false;
    }

    public void SetUsedFalse(){
        used = false;
        button.enabled = true;
    }
}
