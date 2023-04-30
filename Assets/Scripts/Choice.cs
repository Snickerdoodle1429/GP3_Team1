using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Choice : MonoBehaviour
{
    public void Cooperate()
    {
        SceneManager.LoadScene("Lose");
    }

	public void Flee()
	{
		SceneManager.LoadScene("Win");
	}
}
