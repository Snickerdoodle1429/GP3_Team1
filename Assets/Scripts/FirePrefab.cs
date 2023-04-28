using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePrefab : MonoBehaviour
{
    public float damage = 1;
	public float startDelay = 2;
	public float swapDelay = 5;
	public GameObject fire;

	private void Start()
	{
		fire.SetActive(false);
		Invoke("LightFire", startDelay);
	}

	private void LightFire()
	{
		fire.SetActive(true);
		Invoke("StopFire", swapDelay);
	}

	void StopFire()
    {
		fire.SetActive(false);
		Invoke("LightFire", swapDelay);
	}
}
