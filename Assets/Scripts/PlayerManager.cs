using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
	InputManager inputManager;
	PlayerMovement playerMovement;
	CameraManager cameraManager;

	private void Awake()
	{
		inputManager = GetComponent<InputManager>();
		playerMovement = GetComponent<PlayerMovement>();
		cameraManager = FindObjectOfType<CameraManager>();
	}

	private void Update()
	{
		inputManager.HandleAllInputs();
	}

	private void FixedUpdate()
	{
		playerMovement.HandleAllMovement();
	}

	private void LateUpdate()
	{
		cameraManager.HandleAllCameraMovement();
	}
}
