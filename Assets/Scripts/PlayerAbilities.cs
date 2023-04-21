using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
	[Header("Inputs")]
	InputManager inputManager;
	PlayerMovement playerMovement;

	[Header("Fire Ability")]
	public Transform fireSummonPoint;
	public GameObject firePrefab;
	public float fireSpeed = 50;

	[Header("Earth Ability")]
	public GameObject summonPoint;
	public GameObject earthPlatform;
	SummonEarth summonEarth;


	private void Start()
	{
		inputManager = GetComponent<InputManager>();
		playerMovement = GetComponent<PlayerMovement>();
		summonEarth = earthPlatform.GetComponent<SummonEarth>();
	}

	private void Update()
	{
		if(inputManager.fireKey)
		{
			Debug.Log("Fire Activate");
			inputManager.fireKey = false;
			var fire = Instantiate(firePrefab, fireSummonPoint.position, fireSummonPoint.rotation);
			fire.GetComponent<Rigidbody>().velocity = fireSummonPoint.forward * fireSpeed;
		}

		if(playerMovement.canSummonEarth && inputManager.earthKey)
		{
			Debug.Log("Hit");
			summonEarth.ActivateAbility();
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		Vector3 relocate = other.gameObject.transform.position;
		relocate.y = relocate.y - 2;
		summonPoint.transform.position = relocate;
	}
}
