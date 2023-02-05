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
        intro = true;
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
        if(intro){
            Intro();
        }
    }

    public void Intro(){
        switch (introProgress){
            case 0:
                TreePicture.SetActive(false);
                TreeText.SetActive(false);
                EnemyPicture.GetComponent<Image>().sprite = narrator;
                EnemyPicture.GetComponent<Image>().SetNativeSize();
                EnemyPicture.GetComponent<Image>().rectTransform.localScale  = new Vector3(.3f, .3f,1);
                EnemyText.GetComponent<TMPro.TextMeshProUGUI>().text = "The plains of Great-Parsnip! They bloom prosperous and the sun is flooding the land with bright light and warmth.";
                FindObjectOfType<AudioManager>().Play("Intro1");
            break;
            case 1:
                EnemyText.GetComponent<TMPro.TextMeshProUGUI>().text = "Juicy grass, singing birds and pure nature. Right in the middle of this paradise there´s the vein of life called Root 66.";
                FindObjectOfType<AudioManager>().Play("Intro2");
                FindObjectOfType<AudioManager>().Stop("Intro1");
            break;
            case 2:
                EnemyText.GetComponent<TMPro.TextMeshProUGUI>().text = "Everlasting peace. Love and harmony.";
                FindObjectOfType<AudioManager>().Play("Intro3");
                FindObjectOfType<AudioManager>().Stop("Intro2");
            break;
            case 3:
                TreePicture.SetActive(true);
                TreeText.SetActive(true);
                EnemyPicture.SetActive(false);
                EnemyText.SetActive(false);
                TreeText.GetComponent<TMPro.TextMeshProUGUI>().text = "Harmony? Are you stupid?";
                FindObjectOfType<AudioManager>().Play("Intro4");
                FindObjectOfType<AudioManager>().Stop("Intro3");
            break;
            case 4:
                TreeText.GetComponent<TMPro.TextMeshProUGUI>().text = " We´ve got trouble here! Those disgusting ***** from the underground are trying to eat my roots!";
                FindObjectOfType<AudioManager>().Play("Intro5");
                FindObjectOfType<AudioManager>().Stop("Intro4");
            break;
            case 5:
                TreePicture.SetActive(false);
                TreeText.SetActive(false);
                EnemyPicture.SetActive(true);
                EnemyText.SetActive(true);
                EnemyText.GetComponent<TMPro.TextMeshProUGUI>().text = "No, everything is peaceful! Nature is in balance.";
                FindObjectOfType<AudioManager>().Play("Intro6");
                FindObjectOfType<AudioManager>().Stop("Intro5");
            break;
            case 6:
                TreePicture.SetActive(true);
                TreeText.SetActive(true);
                EnemyPicture.SetActive(false);
                EnemyText.SetActive(false);
                TreeText.GetComponent<TMPro.TextMeshProUGUI>().text = "Hey, are you even listening to me?";
                FindObjectOfType<AudioManager>().Play("Intro7");
                FindObjectOfType<AudioManager>().Stop("Intro6");
            break;
            case 7:
                TreeText.GetComponent<TMPro.TextMeshProUGUI>().text = "Damn you, Woody! You ignorant ****! Will you help me already?!";
                FindObjectOfType<AudioManager>().Play("Intro8");
                FindObjectOfType<AudioManager>().Stop("Intro7");
            break;
            case 8:
                TreePicture.SetActive(false);
                TreeText.SetActive(false);
                EnemyPicture.SetActive(true);
                EnemyText.SetActive(true);
                EnemyText.GetComponent<TMPro.TextMeshProUGUI>().text = "Oh! Ohhhh! I can´t heeeaaaar you.";
                FindObjectOfType<AudioManager>().Play("Intro9");
                FindObjectOfType<AudioManager>().Stop("Intro8");
            break;
            case 9:
                EnemyText.GetComponent<TMPro.TextMeshProUGUI>().text = "Because trees can´t speak. It´s rather harmonic and full of love here.";
                FindObjectOfType<AudioManager>().Play("Intro10");
                FindObjectOfType<AudioManager>().Stop("Intro9");
            break;
            case 10:
                TreePicture.SetActive(true);
                TreeText.SetActive(true);
                EnemyPicture.SetActive(false);
                EnemyText.SetActive(false);
                TreeText.GetComponent<TMPro.TextMeshProUGUI>().text = "You´re so ridiculous, Woody! Just go back to waxing your branches, you loser!";
                FindObjectOfType<AudioManager>().Play("Intro11");
                FindObjectOfType<AudioManager>().Stop("Intro10");
            break;
            case 11:
                TreeText.GetComponent<TMPro.TextMeshProUGUI>().text = "Hey you! Yes you, player! I could use a helping hand here!";
                FindObjectOfType<AudioManager>().Play("Intro12");
                FindObjectOfType<AudioManager>().Stop("Intro11");
            break;
            case 12:
                TreeText.GetComponent<TMPro.TextMeshProUGUI>().text = "Look, they´re coming from down there! Those dingy beasts are aiming for my primary root.";
                FindObjectOfType<AudioManager>().Play("Intro13");
                FindObjectOfType<AudioManager>().Stop("Intro12");
                //Turn Off Intro Picture
            break;
            case 13:
                TreeText.GetComponent<TMPro.TextMeshProUGUI>().text = "I mean, they basically just want to nib on my stem, but that´s killing me! You have to defend me by using my root network! You´ll be my eyes!";
                FindObjectOfType<AudioManager>().Play("Intro14");
                FindObjectOfType<AudioManager>().Stop("Intro13");
            break;
            case 14:
                TreeText.GetComponent<TMPro.TextMeshProUGUI>().text = "Hm? You´re asking me why I´m not doing it by myself?";
                FindObjectOfType<AudioManager>().Play("Intro15");
                FindObjectOfType<AudioManager>().Stop("Intro14");
            break;
            case 15:
                TreeText.GetComponent<TMPro.TextMeshProUGUI>().text = "Well, who is looking at the whole underground right now, you or me? I´m just a 2D asset on top of the surface of this map! Now hurry up already!";
                FindObjectOfType<AudioManager>().Play("Intro16");
                FindObjectOfType<AudioManager>().Stop("Intro15");
            break;
            case 16:
                FindObjectOfType<AudioManager>().Stop("Intro6");
                TreePicture.SetActive(false);
                TreeText.SetActive(false);
                EnemyPicture.SetActive(true);
                EnemyText.SetActive(true);
                EnemyPicture.GetComponent<Image>().sprite = isopod;
                EnemyPicture.GetComponent<Image>().SetNativeSize();
                EnemyPicture.GetComponent<Image>().rectTransform.localScale  = new Vector3(1, 1,1);
                EnemyText.GetComponent<TMPro.TextMeshProUGUI>().text = "Woodlouses rule!!! Hell yeah, baby! That´s what I´m talking about! Sweet, juicy roots! C´mon guys, let´s get ready to niiiibbleeee!";
                FindObjectOfType<AudioManager>().Play("Intro17");
                FindObjectOfType<AudioManager>().Stop("Intro16");
            break;
            case 17:
                TreePicture.SetActive(true);
                TreeText.SetActive(true);
                EnemyPicture.SetActive(false);
                EnemyText.SetActive(false);
                TreeText.GetComponent<TMPro.TextMeshProUGUI>().text = "They only speak one language. The language of: IN YOUR FACE! So, take good use of my roots to attack them.";
                FindObjectOfType<AudioManager>().Play("Intro18");
                FindObjectOfType<AudioManager>().Stop("Intro17");
            break;
            case 18:
                //intro = false;
                TreePicture.SetActive(false);
                TreeText.SetActive(false);
            break;
            case 19:
                EnemyPicture.SetActive(true);
                EnemyText.SetActive(true);
                EnemyPicture.GetComponent<Image>().sprite = ladybug;
                EnemyPicture.GetComponent<Image>().SetNativeSize();
                EnemyText.GetComponent<TMPro.TextMeshProUGUI>().text = "The name´s Bug. Ladybug. Roots please. Sludgy, not shaked. Pleased to eat you.";
                FindObjectOfType<AudioManager>().Play("Intro19");
                FindObjectOfType<AudioManager>().Stop("Intro18");
            break;
            case 20:
                TreePicture.SetActive(true);
                TreeText.SetActive(true);
                EnemyPicture.SetActive(false);
                EnemyText.SetActive(false);
                TreeText.GetComponent<TMPro.TextMeshProUGUI>().text = "Not them! Hey, player! Watch out for those flying *****! They can´t be hurt by roots on the ground.";
                FindObjectOfType<AudioManager>().Play("Intro20");
                FindObjectOfType<AudioManager>().Stop("Intro19");
            break;
            case 21:
                //intro = false;
                TreePicture.SetActive(false);
                TreeText.SetActive(false);
            break;
            case 22:
                EnemyPicture.SetActive(true);
                EnemyText.SetActive(true);
                EnemyPicture.GetComponent<Image>().sprite = ant;
                EnemyPicture.GetComponent<Image>().SetNativeSize();
                EnemyText.GetComponent<TMPro.TextMeshProUGUI>().text = "YES! It´s us! The speedy speed-ants of lightning speed! Go, go, go, go, go!!!! GET TO THE TOP! WOHOOO!";
                FindObjectOfType<AudioManager>().Play("Intro21");
                FindObjectOfType<AudioManager>().Stop("Intro20");
            break;
            case 23:
                TreePicture.SetActive(true);
                TreeText.SetActive(true);
                EnemyPicture.SetActive(false);
                EnemyText.SetActive(false);
                TreeText.GetComponent<TMPro.TextMeshProUGUI>().text = "Those hyperactive ***** are really fast! But they lack constitution.";
                FindObjectOfType<AudioManager>().Play("Intro22");
                FindObjectOfType<AudioManager>().Stop("Intro21");
            break;
            case 24:
                //intro = false;
                TreePicture.SetActive(false);
                TreeText.SetActive(false);
            break;
            case 25:
                EnemyPicture.SetActive(true);
                EnemyText.SetActive(true);
                EnemyPicture.GetComponent<Image>().sprite = mouse;
                EnemyPicture.GetComponent<Image>().SetNativeSize();
                EnemyText.GetComponent<TMPro.TextMeshProUGUI>().text = "Mmhh! Uhh! That smells good. I can smell those big juicy roots of yours, tree. I´ll come for you. For your roots!";
                FindObjectOfType<AudioManager>().Play("Intro23");
                FindObjectOfType<AudioManager>().Stop("Intro2");
            break;
            case 26:
                TreePicture.SetActive(true);
                TreeText.SetActive(true);
                EnemyPicture.SetActive(false);
                EnemyText.SetActive(false);
                TreeText.GetComponent<TMPro.TextMeshProUGUI>().text = "Damn, that´s the worst of all beasts! Brace yourself, player! They´re pretty tough!";
                FindObjectOfType<AudioManager>().Play("Intro24");
                FindObjectOfType<AudioManager>().Stop("Intro23");
            break;
            case 27:
                //intro = false;
                FindObjectOfType<AudioManager>().Stop("Intro24");
                TreePicture.SetActive(false);
                TreeText.SetActive(false);
            break;
        }
        introProgress += 1;
    }
}
