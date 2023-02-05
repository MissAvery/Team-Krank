using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
   
    public string type;
    public Collider2D col;
    public string mode;
    private GameObject trapPoint;
    private bool cool;

    public Sprite active, cooldown, attack;
    void Start()
    {
        mode = "InRound";     //temporary

        if(type == "Strong" || type == "Wall" || type == "Multiple"){
            col.enabled = false;
        }
    }

    public void Clicked(){

        if (mode == "InRound" && !cool){
            switch (type){
            case "Strong":
                col.enabled = true;
                Invoke("DeactivateTimer",0.5f);
                GetComponent<SpriteRenderer>().sprite = active;
            break;
            case "Wall":
                col.enabled = true;
                Invoke("DeactivateTimer",2f);
                GetComponent<SpriteRenderer>().sprite = active;
            break;
            case "Multiple":
                col.enabled = true;
                Invoke("DeactivateTimer",3f);
                GetComponent<SpriteRenderer>().sprite = active;
            break;
            /*case "Weakening":
                col.enabled = true;
                Invoke("DeactivateTimer",2f);
            break;
            case "Trapdoor":
                    //Öffne Trapdoor
                    Invoke("DeactivateTimer",6f);
            break;*/
            }
            int rand = Random.Range(1,3);
            if (rand == 1 && (type == "Strong" || type == "Wall" || type == "Multiple" || type == "Weakening")){
                FindObjectOfType<AudioManager>().Play("WurzelAngriff1");
            } else if (type == "Strong" || type == "Wall" || type == "Multiple" || type == "Weakening"){
                FindObjectOfType<AudioManager>().Play("WurzelAngriff2");
            }
        } 
        
        else if(mode == "BetweenRounds"){
            trapPoint.GetComponent<TrapPoint>().SetUsedFalse();
            FindObjectOfType<AudioManager>().Play("FalleEntfernen");
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
            Invoke("Cooldown",5f);
            cool = true;
            GetComponent<SpriteRenderer>().sprite = cooldown;
        }

    }

    public void Cooldown(){
        cool = false;
        if (type == "Strong" || type == "Wall" || type == "Multiple"){
            GetComponent<SpriteRenderer>().sprite = active;
        }
    }

    public void SetTrapPoint(GameObject point){
        trapPoint = point;
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Enemy"){
            switch (type){
            case "Strong":
                other.gameObject.GetComponent<Enemies>().DooDmg(15);
            break;
            case "Wall":
                other.gameObject.GetComponent<Enemies>().DooDmg(5);
            break;
            case "Multiple":
                other.gameObject.GetComponent<Enemies>().DooDmg(5);
            break;
            case "Weakening":
               other.gameObject.GetComponent<Enemies>().DoPercDmg(10);
            break;
            case "Slowness":
                other.gameObject.GetComponent<Enemies>().SlowDown();
                int rand = Random.Range(1,3);
                if (rand == 1){
                    FindObjectOfType<AudioManager>().Play("Verlangsamung1");
                } else {
                    FindObjectOfType<AudioManager>().Play("Verlangsamung2");
                }
            break;
            case "Spikes":
                MultipleDamage(other.gameObject);
                other.gameObject.GetComponent<Enemies>().SetDamageBool(true);
            break;
            }
        }
        
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.tag == "Enemy"){
            switch (type){
                case "Spikes":
                    other.gameObject.GetComponent<Enemies>().SetDamageBool(false);
                break;
            }
        }
    }

    public void MultipleDamage(GameObject enemy){
        if (enemy.GetComponent<Enemies>().GetDamageBool()){
            enemy.GetComponent<Enemies>().DooDmg(1);
            Invoke("MultipleDamage",0.5f);
        }
        
    }

    public void StopDamage(){

    }

}
