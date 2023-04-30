using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Cutscene : MonoBehaviour
{
    public string sceneName;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Q))
		{
			Debug.Log("skip");
			SceneManager.LoadScene(sceneName);
		}
	}
}
