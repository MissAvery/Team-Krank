using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject optionsScreen;
    private bool pause;

    void Start(){
        pause = false;
    }

    public void SlowTime(){
        Time.timeScale = 0.01f;
    }
    public void NormalTime(){
        Time.timeScale = 1f;
    }

    public void OnPause(){
        if(!pause){
            SlowTime();
            pauseScreen.SetActive(true);
            pause = true;
        } else {
            NormalTime();
            optionsScreen.SetActive(false);
            pauseScreen.SetActive(false);
            pause = false;
        }
    }
}
