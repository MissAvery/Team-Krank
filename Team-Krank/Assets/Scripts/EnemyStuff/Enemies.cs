using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{   
    [SerializeField]
    private Transform[] pathpoints;

    [SerializeField]
    public float walkSpeed;

    [SerializeField] private float startHealth;
    public float currentHealth;
    public bool dead = false;
    public GameObject enemy;


    public float damage;
    public float prctdmg;
    public float speed;

    private bool cooldown;

    private bool takingDamage;
    

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

    private void Awake(){
        currentHealth = startHealth;
    }

    public void damageTaken(float _damage){
        
        if (currentHealth > 0){
            currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startHealth);
            /*player aua :( */
        }
        else {
            if (dead == false){
                
                /*if (GetComponent<Walk>() != null){*/
                enemy.SetActive(false);
                dead = true;
            }

            /* ded :(*/
        }
    }


    /*public void OnTriggerEnter2D(Collider2D collision){
        if (collision.tag == "Enemy"){
            collision.damageTaken(damage);
        }
    }*/
    public void DooDmg(int dmg){
        damageTaken(dmg);
    }

    public void DoPercDmg(int perc){
        prctdmg = (currentHealth / 100) * perc;
        damageTaken(prctdmg);
    }

    public void SlowDown(){
        if (!cooldown){
            walkSpeed = 0.5f;
            Invoke("StopSlowness",10f);
            cooldown = true;
        }
    }

    public void StopSlowness(){
        cooldown = false;
        walkSpeed = 1f;
    }

    public bool GetDamageBool(){
        return takingDamage;
    }

    public void SetDamageBool(bool newBool){
        takingDamage = newBool;
    }
}
