using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausedMenu : MonoBehaviour
{
    public GameObject pausedMenu;
    public static bool isPaused;
    public AudioSource audioSource;
    public GameObject crosshairs;
	public GameObject levelSelect;
	public GameObject overallStorage;

	void Start()
    {
		Invoke("WhenStart", 0.01f);
	}

	void WhenStart()
	{
		pausedMenu.SetActive(false);
		levelSelect.SetActive(false);
		isPaused = false;
		Time.timeScale = 1f;
		crosshairs.SetActive(true);
	}

	#region Pause
	public void PauseButton()
    {
		Debug.Log("Pause");

		if (isPaused)
		{
			ResumeGame();
		}

		else
		{
			PauseGame();
		}
	}

    public void PauseGame()
    {
        Debug.Log("Paused");

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        pausedMenu.SetActive(true);

        Time.timeScale = 0f;
        isPaused = true;
        crosshairs.SetActive(false);

        PlayerMovement controller = GetComponent<PlayerMovement>();
        audioSource.Pause();
    }

    public void ResumeGame()
    {
        Debug.Log("Unpaused");

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pausedMenu.SetActive(false);
		levelSelect.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        crosshairs.SetActive(true);

        audioSource.Play(0);
    }
	#endregion

	#region Level Select
	public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
		Destroy(overallStorage);
		isPaused = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

	public void LevelSelect()
	{
		levelSelect.SetActive(true);
		pausedMenu.SetActive(false);
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
		levelSelect.SetActive(false);
		pausedMenu.SetActive(true);
	}
	#endregion
}