using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Options : MonoBehaviour
{

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    
}