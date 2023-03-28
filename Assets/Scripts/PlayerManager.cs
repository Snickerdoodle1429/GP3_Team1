using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
	Animator animator;
	InputManager inputManager;
	PlayerMovement playerMovement;
	CameraManager cameraManager;

	private void Awake()
	{
		inputManager = GetComponent<InputManager>();
		playerMovement = GetComponent<PlayerMovement>();
		cameraManager = FindObjectOfType<CameraManager>();
		animator = GetComponent<Animator>();
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

		playerMovement.isJumping = animator.GetBool("isJumping");
		animator.SetBool("isGrounded", playerMovement.isGrounded);
	}
}
