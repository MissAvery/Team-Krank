using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startHealth;
    public float currentHealth;
    public bool dead = false;
    public GameObject enemy;

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

}
