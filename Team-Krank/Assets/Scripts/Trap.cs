using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
   
    public string type;
    public Collider2D col;
    private string mode;
    private GameObject trapPoint;
    void Start()
    {
        if(type == "Strong" || type == "Wall" || type == "Multiple" || type == "Weakening"){
            col.enabled = false;
        }
    }

    public void Clicked(){

        if (mode == "InRound"){
            switch (type){
            case "Strong":
                col.enabled = true;
                Invoke("DeactivateTimer",0.5f);
            break;
            case "Wall":
                col.enabled = true;
                Invoke("DeactivateTimer",2f);
            break;
            case "Multiple":
                col.enabled = true;
                Invoke("DeactivateTimer",3f);
            break;
            case "Weakening":
                col.enabled = true;
                Invoke("DeactivateTimer",2f);
            break;
            case "Trapdoor":
                    //Öffne Trapdoor
                    Invoke("DeactivateTimer",6f);
            break;
            }
        } 
        
        else if(mode == "BetweenRounds"){
            trapPoint.GetComponent<TrapPoint>().SetUsedFalse();
            Remove();
        }
        
    }

    public void Setmode(string newMode){
        mode = newMode;
    }
    
    public void Remove(){
        Destroy(gameObject);
    }
    
    public void DeactivateTimer(){
        if(type == "Trapdoor"){
            //Schließe Trapdoor
        } else{
            col.enabled = false;
        }

    }

    public void SetTrapPoint(GameObject point){
        trapPoint = point;
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Enemy"){
            switch (type){
            case "Strong":
                //other.gameObject.Damage(15);
            break;
            case "Wall":
                //other.gameObject.Damage(5);
            break;
            case "Multiple":
                //other.gameObject.Damage(5);
            break;
            case "Weakening":
                //other.gameObject.Weakening();
            break;
            case "Slowness":
                //other.gameObject.SlowDown();
            break;
            case "Spikes":
                //other.gameObject.MultipleDamage(1);
            break;
            }
        }
        
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.tag == "Enemy"){
            switch (type){
                case "Spikes":
                    //other.gameObject.StopMultipleDamage();
                break;
            }
        }
    }

}
