using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaceSprite : MonoBehaviour
{
    GameObject[] GlobalBasicBalancing;
    BasicBalacing balancing;

    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite destroyedHeart;



    private void FixedUpdate() {
        if (balancing.gameOver) {
            spriteRenderer.sprite = destroyedHeart;
            Time.timeScale = 0.1f;
        }
    }





    private void Awake() {
        GlobalBasicBalancing = GameObject.FindGameObjectsWithTag("GlobalBalancing");
        balancing = GlobalBasicBalancing[0].GetComponent<BasicBalacing>();
    }
}
