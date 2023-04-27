using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
	public GameObject selection;
	public GameObject overallStorage;
    public AudioSource audio;

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
        audio.Play();
    }

	public void QuitGame()
	{
		Application.Quit();
        audio.Play();
    }

	public void Select()
	{
		selection.SetActive(true);
        audio.Play();
    }

	public void LoadTutorial()
	{
		SceneManager.LoadScene("Art Area");
        audio.Play();
    }

	public void LoadWater()
	{
		SceneManager.LoadScene("Water_Level");
        audio.Play();
    }

	public void LoadEarth()
	{
		SceneManager.LoadScene("Earth_Level");
        audio.Play();
    }

	public void LoadFire()
	{
		SceneManager.LoadScene("Fire_Level");
        audio.Play();
    }

	public void ReturnToPause()
	{
		selection.SetActive(false);
        audio.Play();
    }
}
