using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;


public class Cutscene : MonoBehaviour
{
    public string sceneName;
	public VideoPlayer videoPlayer;
	public float duration;

	private void Awake()
	{
		duration = (float)videoPlayer.length;
		Invoke("Skipping", duration);
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Q))
		{
			Skipping();
		}
	}

	public void Skipping()
	{
		SceneManager.LoadScene(sceneName);
	}
}
