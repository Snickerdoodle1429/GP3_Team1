using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
	public GameObject selection;
	public GameObject overallStorage;
    public AudioSource audioSource;

    void Start()
	{
		Invoke("WhenStart", 0.01f);
	}

	void WhenStart()
	{
		selection.SetActive(false);
	}

	public void GoToMainMenu()
	{
		SceneManager.LoadScene("Menus");
		Destroy(overallStorage);
        audioSource.Play(0);
    }

	public void QuitGame()
	{
		Application.Quit();
        audioSource.Play(0);
    }

	public void Select()
	{
		selection.SetActive(true);
        audioSource.Play(0);
    }

	public void LoadTutorial()
	{
		SceneManager.LoadScene("Art Area");
        audioSource.Play(0);
    }

	public void LoadWater()
	{
		SceneManager.LoadScene("Water_Level");
        audioSource.Play(0);
    }

	public void LoadEarth()
	{
		SceneManager.LoadScene("Earth_Level");
        audioSource.Play(0);
    }

	public void LoadFire()
	{
		SceneManager.LoadScene("Fire_Level");
        audioSource.Play(0);
    }

	public void ReturnToPause()
	{
		selection.SetActive(false);
        audioSource.Play(0);
    }
}
