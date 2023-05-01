using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausedMenu : MonoBehaviour
{
    public GameObject pausedMenu;
    public static bool isPaused;
    public AudioSource audioSource;
	public GameObject levelSelect;
    public GameObject controlsScreen;
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

        audioSource.Play(0);
    }
	#endregion

	#region Level Select
	public void GoToMainMenu()
    {
        SceneManager.LoadScene("Menus");
		Destroy(overallStorage);
		isPaused = false;

        audioSource.Play(0);
    }

    public void OpenControls()
    {
        audioSource.Play(0);
        controlsScreen.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();

        audioSource.Play(0);
    }

	public void LevelSelect()
	{
		levelSelect.SetActive(true);
		pausedMenu.SetActive(false);
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
		levelSelect.SetActive(false);
        controlsScreen.SetActive(false);
        pausedMenu.SetActive(true);
        audioSource.Play(0);
    }
	#endregion
}