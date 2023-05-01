using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject creditsScreen;
    public GameObject controlsScreen;
    public AudioSource audio;

    public void PlayGame()
    {
        audio.Play();
        SceneManager.LoadScene("OpenScene");
    }

    public void QuitGame()
    {
        audio.Play();
        Application.Quit();
    }

    public void OpenControls()
    {
        audio.Play();
        controlsScreen.SetActive(true);
    }

    public void OpenCredits()
    {
        audio.Play();
        creditsScreen.SetActive(true);
    }

    public void ReturnToMenu()
    {
        audio.Play();
        creditsScreen.SetActive(false);
        controlsScreen.SetActive(false);
    }

    public void Title()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
