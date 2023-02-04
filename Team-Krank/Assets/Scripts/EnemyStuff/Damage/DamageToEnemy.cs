using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageToEnemy : MonoBehaviour
{
    [SerializeField] private float damage;
    public GameObject walkspeed;
    public float speed;



    public void OnTriggerEnter2D(Collider2D collision){
        if (collision.tag == "Enemy"){
            collision.GetComponent<Health>().damageTaken(damage);
        }
    }
    public void DooDmg(int dmg){
        GetComponent<Health>().damageTaken(dmg);
    }
    public void SlowDown(){
        speed = walkspeed.GetComponent<Walk>().walkSpeed;
        speed -= 2f;

    }
}
