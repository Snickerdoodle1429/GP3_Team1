using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    InputManager inputManager;
    
    private Vector3 moveDirection;
    Transform cameraObject;
    Rigidbody playerRigidbody;

    public bool isSprinting;
    public bool isJumping;

    [Header("Movement Speeds")]
    public float walkingSpeed = 1.5f;
    public float runningSpeed = 3;
    public float sprintingSpeed = 5;
    public float rotationSpeed = 15;

    [Header("Jump")]
    public float jumpHeight = 1;
    public float gravityIntensity = -15;
    public bool doubleJump;
    public bool readyToJump;
    public bool hasJumped;
    public float jumpBoost;

	[Header("Falling")]
    public float inAirTimer;
    public float leapingVelocity = 5;
    public float fallingSpeed = 100;

	[Header("Ground Check")]
	public bool isGrounded;
	public LayerMask whatIsGround;
    public float playerHeight = 3.6f;

    [Header("Earth Ability")]
    public LayerMask validEarth;
    public bool canSummon;
    Vector3 lookDirection;
    public GameObject summonPoint;
    SummonEarth summonEarth;

	void Awake()
    {
        inputManager = GetComponent<InputManager>();
        playerRigidbody = GetComponent<Rigidbody>();
        cameraObject = Camera.main.transform;
    }

	private void Update()
	{
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.1f, whatIsGround);
    }

	public void HandleAllMovement()
    {
        HandleFalling();
        HandleMovement();
        HandleRotation();
    }

    private void HandleMovement()
    {
        moveDirection = cameraObject.forward * inputManager.verticalInput;
        moveDirection = moveDirection + cameraObject.right * inputManager.horizontalInput;
        moveDirection.Normalize();

        if (isGrounded)
        {
            moveDirection.y = 0;
            doubleJump = true;
            hasJumped = false;
        }

        if (isSprinting)
        {
            moveDirection = moveDirection * sprintingSpeed;
        }
        else
        {
            if (inputManager.moveAmount >= 0.5f)
            {
                moveDirection = moveDirection * runningSpeed;
            }
            else
            {
                moveDirection = moveDirection * walkingSpeed;
            }
        }

            moveDirection = moveDirection * runningSpeed;

        Vector3 movementVelocity = moveDirection;
        playerRigidbody.velocity = movementVelocity;
    }

    private void HandleRotation()
    {
        Vector3 targetDirection = Vector3.zero;

        targetDirection = cameraObject.forward * inputManager.verticalInput;
        targetDirection = targetDirection + cameraObject.right * inputManager.horizontalInput;

        targetDirection.Normalize();
        targetDirection.y = 0;

        if (targetDirection == Vector3.zero)
        {
            targetDirection = transform.forward;
        }

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        transform.rotation = playerRotation;
    }

    private void HandleFalling()
    {
        if (!isGrounded)
        {
            inAirTimer = inAirTimer + Time.deltaTime;
            playerRigidbody.AddForce(transform.forward * leapingVelocity);
            playerRigidbody.AddForce(Vector3.down * fallingSpeed * 5);
        }

        if (isGrounded)
        {
            inAirTimer = 0;
        }
	}

    public void HandleJumping()
    {
        if (isGrounded || doubleJump)
        {
			isJumping = true;
            if (hasJumped)
            {
                doubleJump = false;
            }

            playerRigidbody.AddForce(new Vector3(0, jumpHeight * 2 * playerHeight * jumpBoost, 0), ForceMode.Impulse);
			Invoke("StopJump", 1);
		}

		// float jumpingVelocity = Mathf.Sqrt(-3 * gravityIntensity * jumpHeight);
		// Vector3 playerVelocity = moveDirection;
		// playerVelocity.y = jumpingVelocity;
		// playerRigidbody.velocity = playerVelocity;
    }

    void StopJump()
    {
		hasJumped = true;
		isJumping = false;
		readyToJump = true;
	}

	private void OnCollisionEnter(Collision collision)
	{
        jumpBoost = 5;
	}

	private void OnCollisionExit(Collision collision)
	{
        jumpBoost = 1;
	}

    public void EarthActivate()
    {
		RaycastHit hit;
		canSummon = Physics.Raycast(transform.position, Vector3.forward , out hit, 5, validEarth);

        if (canSummon)
        {
            Debug.Log("Recieved");
			//summonPoint.transform.position = hit.transform.position;
            summonEarth.ActivateAbility();
		}
	}
}
