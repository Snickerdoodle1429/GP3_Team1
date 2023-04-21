using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalActivation : MonoBehaviour
{
    public Overall overall;
	public GameObject levelOne;
	public GameObject levelTwo;
	public GameObject levelThree;
	public GameObject ending;

	private void Update()
	{
		if(overall.tutorialFinish)
		{
			Debug.Log("One Activate");
			levelOne.SetActive(true);
		}

		if(overall.firstLevel)
		{
			Debug.Log("Two Activate");
			levelTwo.SetActive(true);
		}

		if(overall.secondLevel)
		{
			Debug.Log("Three Activate");
			levelThree.SetActive(true);
		}

		if(overall.thirdLevel)
		{
			Debug.Log("End Activate");
			ending.SetActive(true);
		}
	}
}
