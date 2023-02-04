using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageToEnemy : MonoBehaviour
{
    public float damage;
    public GameObject walkspeed;
    public GameObject healthstat;
    public float prctdmg;
    public float speed;
    public float timer;
    public float duration;

    public void OnTriggerEnter2D(Collider2D collision){
        if (collision.tag == "Enemy"){
            collision.GetComponent<Health>().damageTaken(damage);
        }
    }
    public void DooDmg(int dmg){
        GetComponent<Health>().damageTaken(dmg);
    }

    public void Update(){
    timer += Time.deltaTime;
    
    void SlowDown(float slow){
        if (timer >= duration){
            speed = walkspeed.GetComponent<Walk>().walkSpeed;
            speed -= slow;
         }
      }
    }

    public void DoPercDmg(int perc){
        prctdmg = (healthstat.GetComponent<Health>().currentHealth / 100) * perc;
        GetComponent<Health>().damageTaken(prctdmg);
    }
}
