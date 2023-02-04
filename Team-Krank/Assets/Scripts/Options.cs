using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource audioSource;

    private void Start()
    {
        volumeSlider.value = audioSource.volume;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void UpdateVolume()
    {
        audioSource.volume = volumeSlider.value;
    }
}