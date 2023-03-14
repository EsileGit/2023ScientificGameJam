using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ApplyPlay()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void ApplyIntro()
    {
        SceneManager.LoadScene("Intro");
    }

    public void ApplyQuit()
    {
        Application.Quit();
    }
}
