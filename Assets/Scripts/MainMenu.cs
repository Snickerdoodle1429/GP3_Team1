using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject creditsScreen;
    public GameObject controlsScreen;

    public void Start()
    {
        creditsScreen.SetActive(false);
        controlsScreen.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenControls()
    {
        controlsScreen.SetActive(true);
    }

    public void OpenCredits()
    {
        creditsScreen.SetActive(true);
    }

    public void ReturnToMenu()
    {
        creditsScreen.SetActive(false);
        controlsScreen.SetActive(false);
    }

    public void Title()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
