using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    // Hier wurden die Paths aus dem Global Balancing übernommen mittels balancing.pathPoints
    //[SerializeField]
    //private Transform[] pathPoints;

    [SerializeField]
    public float walkSpeed;

    /*[SerializeField]*/ private float startHealth;
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
        transform.position = balancing.pathPoints[pathpointIndex].transform.position;
    }

    private void Update (){
        walki();
    }

    public void walki(){

        if (pathpointIndex <= balancing.pathPoints.Count - 1){

             transform.position = Vector2.MoveTowards(transform.position, balancing.pathPoints[pathpointIndex].transform.position, walkSpeed * Time.deltaTime);

            if (transform.position == balancing.pathPoints[pathpointIndex].transform.position){

                pathpointIndex += 1;
            }
        }
    }

    private void Awake(){
        StartUp();
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


    void OnTriggerEnter2D(Collider other) {
        if (other.CompareTag("Teleporter")) {
            Teleporter teleporter = other.GetComponent<Teleporter>();
            if (teleporter.destinationTeleport) {
                Teleport(teleporter);
            }
        }
    }


    void Teleport(Teleporter teleporter) {

    }



    [SerializeField] bool Kellerassel, Ameise, Marienkäfer, Maus;

    void receiveBalancingValues() {

        if (Kellerassel) {
            startHealth = balancing.enemyStartHealth[0];
            walkSpeed = balancing.enemySpeed[0] / 100;
        }
        else if (Ameise) {
            startHealth = balancing.enemyStartHealth[1];
            walkSpeed = balancing.enemySpeed[1] / 100;
        }
        else if (Marienkäfer) {
            startHealth = balancing.enemyStartHealth[2];
            walkSpeed = balancing.enemySpeed[2] / 100;
        }
        else if (Maus) {
            startHealth = balancing.enemyStartHealth[3];
            walkSpeed = balancing.enemySpeed[3] / 100;
        }
        else { }

    }

    //
    GameObject[] GlobalBasicBalancing;
    BasicBalacing balancing;
    void StartUp() {
        GlobalBasicBalancing = GameObject.FindGameObjectsWithTag("GlobalBalancing");
        balancing = GlobalBasicBalancing[0].GetComponent<BasicBalacing>();
        // local variables
        receiveBalancingValues();
    }
}
