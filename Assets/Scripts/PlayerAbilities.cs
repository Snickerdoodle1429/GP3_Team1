using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
	[Header("Inputs")]
	InputManager inputManager;

	[Header("Fire Ability")]
	public Transform fireSummonPoint;
	public GameObject firePrefab;
	public float fireSpeed = 50;

	private void Start()
	{
		inputManager = GetComponent<InputManager>();
	}

	private void Update()
	{
		if(inputManager.fireKey)
		{
			inputManager.fireKey = false;
			var fire = Instantiate(firePrefab, fireSummonPoint.position, fireSummonPoint.rotation);
			fire.GetComponent<Rigidbody>().velocity = fireSummonPoint.forward * fireSpeed;
		}
	}
}
