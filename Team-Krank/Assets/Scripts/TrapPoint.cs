using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapPoint : MonoBehaviour
{
    private string mode;
    private bool used, openUI;
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

    private PointList list;
    public bool locked;
    void Start()
    {
        mode = "BetweenRounds";
        //Temporary

        used = false;
        openUI = false;
        trapUI.enabled = false;
        //locked = true;

        list = GameObject.FindGameObjectWithTag("List").GetComponent<PointList>();
        list.points.Add(this.gameObject);
    }

   public void Clicked(){

    if(mode == "BetweenRounds"){
        if(!used && !openUI && !locked){
            foreach (GameObject i in list.points){
                i.GetComponent<TrapPoint>().CloseUI();
            }
            trapUI.enabled = true;
            openUI = true;
            button.enabled = false;
            FindObjectOfType<AudioManager>().Play("FallenMenu");
        }
    }
   }

   public void Setmode(string newMode){
        mode = newMode;
        if (trap != null){
            trap.GetComponent<Trap>().Setmode(newMode);
        }
    }

    public void BuildTrap(string trapType){
        switch (trapType){
            case "Strong":
                trap = Instantiate(StrongRoot, transform.position + new Vector3(0,-0.15f,0), Quaternion.identity);
            break;
            case "Wall":
                trap = Instantiate(WallRoot, transform.position + new Vector3(0,0.6f,0), Quaternion.identity);
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
                trap = Instantiate(Spikes, transform.position + new Vector3(0,-0.6f,0), Quaternion.identity);
            break;
            case "Slowness":
                trap = Instantiate(SlownessField, transform.position + new Vector3(0,-0.1f,0), Quaternion.identity);
            break;
            }
            int rand = Random.Range(1,3);
            if (rand == 1){
                FindObjectOfType<AudioManager>().Play("FallePlatzieren1");
            } else {
                FindObjectOfType<AudioManager>().Play("FallePlatzieren2");
            }

            trap.GetComponent<Trap>().SetTrapPoint(gameObject);
            trapUI.enabled = false;
            used = true;
            openUI = false;
            GetComponent<SpriteRenderer>().enabled = false;
    }

    public void SetUsedFalse(){
        used = false;
        button.enabled = true;
        openUI = false;
        GetComponent<SpriteRenderer>().enabled = true;
    }

    public void CloseUI(){
        trapUI.enabled = false;
        openUI = false;
        if (!used){
            button.enabled = true;
        }
    }

    public void Unlock(){
        locked = false;
    }
}
