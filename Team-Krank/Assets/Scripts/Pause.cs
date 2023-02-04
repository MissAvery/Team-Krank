using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Pause : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject optionsScreen;
    private bool pause;
    private bool intro;

    public GameObject introScreen;
    public GameObject TreePicture;
    public GameObject TreeText;
    public GameObject EnemyPicture;
    public GameObject EnemyText;

    private int introProgress;


    public Sprite narrator, isopod, ladybug, ant, mouse;

    void Start(){
        pause = false;
        introProgress = 0;
    }

    public void SlowTime(){
        Time.timeScale = 0.01f;
    }
    public void NormalTime(){
        Time.timeScale = 1f;
    }

    public void OnPause(){
        if(!intro){
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

    public void OnNextSpeech(){
        Intro();
    }

    public void Intro(){
        switch (introProgress){
            case 0:
                intro = true;
                TreePicture.SetActive(false);
                TreeText.SetActive(false);
                EnemyPicture.GetComponent<Image>().sprite = narrator;
                EnemyText.GetComponent<TMPro.TextMeshProUGUI>().text = "Die Ebenen von Groß-Pastinak! Sie blühen so prächtig, die Sonne taucht alles in Wärme und Licht.";
            break;
            case 1:
                EnemyText.GetComponent<TMPro.TextMeshProUGUI>().text = "Saftiges Gras, singende Vögel und Natur pur. Mitten durch dieses Paradies führt die Straße des Lebens, die Root 66.";
            break;
            case 2:
                EnemyText.GetComponent<TMPro.TextMeshProUGUI>().text = "Es herrscht Frieden. Liebe und Harmonie.";
            break;
            case 3:
                TreePicture.SetActive(true);
                TreeText.SetActive(true);
                EnemyPicture.SetActive(false);
                EnemyText.SetActive(false);
                TreeText.GetComponent<TMPro.TextMeshProUGUI>().text = "Harmonie?! Bist du bescheuert? Hier gibt’s Stress!";
            break;
            case 4:
                TreeText.GetComponent<TMPro.TextMeshProUGUI>().text = "Diese widerlichen ***** aus der Erde wollen an meine Wurzeln!";
            break;
            case 5:
                TreePicture.SetActive(false);
                TreeText.SetActive(false);
                EnemyPicture.SetActive(true);
                EnemyText.SetActive(true);
                EnemyText.GetComponent<TMPro.TextMeshProUGUI>().text = "Nein, alles ist friedlich! Die Natur ist im Einklang mit sich selbst.";
            break;
            case 6:
                TreePicture.SetActive(true);
                TreeText.SetActive(true);
                EnemyPicture.SetActive(false);
                EnemyText.SetActive(false);
                TreeText.GetComponent<TMPro.TextMeshProUGUI>().text = "Hey, hörst du mir überhaupt zu?!";
            break;
            case 7:
                TreeText.GetComponent<TMPro.TextMeshProUGUI>().text = "Verdammt, Woody! Du ignorantes *****! Hilf mir gefälligst!";
            break;
            case 8:
                TreePicture.SetActive(false);
                TreeText.SetActive(false);
                EnemyPicture.SetActive(true);
                EnemyText.SetActive(true);
                EnemyText.GetComponent<TMPro.TextMeshProUGUI>().text = "Oh! Ohhhh! Ich kann dich nicht höööööreeeen.";
            break;
        }
        introProgress += 1;
    }
}
