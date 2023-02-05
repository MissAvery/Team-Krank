using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    // Hier wurden die Paths aus dem Global Balancing �bernommen mittels balancing.pathPoints
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

        if(Maus){
            int rand = Random.Range(1,3);
            if (rand == 1){
                FindObjectOfType<AudioManager>().Play("MausSpawn1");
            } else {
                FindObjectOfType<AudioManager>().Play("MausSpawn2");
            }
        } else if(Ameise){
            int rand = Random.Range(1,3);
            if (rand == 1){
                FindObjectOfType<AudioManager>().Play("AmeiseSpawn1");
            } else {
                FindObjectOfType<AudioManager>().Play("AmeiseSpawn2");
            }
        } else if(Marienkäfer){
            int rand = Random.Range(1,3);
            if (rand == 1){
                FindObjectOfType<AudioManager>().Play("MariSpawnt1");
            } else if (rand ==2){
                FindObjectOfType<AudioManager>().Play("MariSpawnt2");
            } else {
                FindObjectOfType<AudioManager>().Play("MariSpawnt3");
            }
        } else if(Kellerassel){
            int rand = Random.Range(1,3);
            if (rand == 1){
                FindObjectOfType<AudioManager>().Play("AsselSpawn1");
            } else {
                FindObjectOfType<AudioManager>().Play("AsselSpawn2");
            }
        } 
    }

    private void Update (){
        walki();
    }
    bool alreadyTeleported = false;
    public void walki(){

        if (pathpointIndex <= balancing.pathPoints.Count - 1){

             transform.position = Vector2.MoveTowards(transform.position, balancing.pathPoints[pathpointIndex].transform.position, walkSpeed * Time.deltaTime);

            if (!balancing.useTeleportOrPath) {
                if (alreadyTeleported) {
                    pathpointIndex += 1;
                    alreadyTeleported = false;
                    MirrorSprite();
                }
            }
            //if (!balancing.useTeleportOrPath) {
            //    if (ownApproximate(transform.position.x, balancing.pathPoints[pathpointIndex].transform.position.x, balancing.pathCompletedThreshold) && ownApproximate(transform.position.y, balancing.pathPoints[pathpointIndex].transform.position.y, balancing.pathCompletedThreshold)) {
            //        pathpointIndex += 1;
            //    }
            //}
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
                
                if(!Maus){
                    int rand = Random.Range(1,3);
                    if (rand == 1){
                        FindObjectOfType<AudioManager>().Play("InsektKill1");
                    } else {
                        FindObjectOfType<AudioManager>().Play("InsektKill2");
                    }
                } else{
                    int rand = Random.Range(1,3);
                    if (rand == 1){
                        FindObjectOfType<AudioManager>().Play("MausKill1");
                    } else {
                        FindObjectOfType<AudioManager>().Play("MausKill2");
                    }
                }

                /*if (GetComponent<Walk>() != null){*/
                //enemy.SetActive(false);
                Destroy(enemy);
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


    void OnTriggerEnter2D(Collider2D other) {
    if (other.CompareTag("Teleporter")) {
            Teleporter teleporter = other.GetComponent<Teleporter>();
            if (teleporter.destinationTeleport) {
                transform.position = teleporter.destinationTeleport.transform.position;
                alreadyTeleported = true;
            }
        }
    }



    [SerializeField] bool Kellerassel, Ameise, Marienkäfer, Maus;

    void ReceiveBalancingValues() {

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

    [SerializeField] SpriteRenderer spriteObject;
    void MirrorSprite() {
        if (spriteObject.flipX) {
            spriteObject.flipX = false;
        }
        else if (!spriteObject.flipX) {
            spriteObject.flipX = true;
        }
    }

    //
    GameObject[] GlobalBasicBalancing;
    BasicBalacing balancing;
    void StartUp() {
        GlobalBasicBalancing = GameObject.FindGameObjectsWithTag("GlobalBalancing");
        balancing = GlobalBasicBalancing[0].GetComponent<BasicBalacing>();
        // local variables
        ReceiveBalancingValues();
    }
}
