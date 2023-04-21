using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overall : MonoBehaviour
{
    public bool tutorialFinish;
    public bool firstLevel;
    public bool secondLevel;
    public bool thirdLevel;

	private void Awake()
	{
		DontDestroyOnLoad(gameObject);

		tutorialFinish = false;
		firstLevel = false;
		secondLevel = false;
		thirdLevel = false;
	}
}
