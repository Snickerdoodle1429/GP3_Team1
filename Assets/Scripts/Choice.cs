using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Choice : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Cooperate()
    {
        SceneManager.LoadScene("Cooperate");
    }

	public void Flee()
	{
		SceneManager.LoadScene("Flee");
	}
}
