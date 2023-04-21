using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
	public GameObject selection;
	public GameObject overallStorage;

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
		SceneManager.LoadScene("MainMenu");
		Destroy(overallStorage);
	}

	public void QuitGame()
	{
		Application.Quit();
	}

	public void Select()
	{
		selection.SetActive(true);
	}

	public void LoadTutorial()
	{
		SceneManager.LoadScene("Art Area");
	}

	public void LoadWater()
	{
		SceneManager.LoadScene("Water_Level");
	}

	public void LoadEarth()
	{
		SceneManager.LoadScene("Earth_Level");
	}

	public void LoadFire()
	{
		SceneManager.LoadScene("Fire_Level");
	}

	public void ReturnToPause()
	{
		selection.SetActive(false);
	}
}
