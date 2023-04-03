using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    InputManager inputManager;
    PlayerManager playerManager;
    public AnimatorManager animatorManager;

    private Vector3 moveDirection;
    Transform cameraObject;
    Rigidbody playerRigidbody;
    public Collider playerCapsule;

    [Header("Movement")]
    public bool isSprinting;
    public bool isJumping;

    [Header("Movement Speeds")]
    public float walkingSpeed = 1.5f;
    public float runningSpeed = 3;
    public float sprintingSpeed = 5;
    public float rotationSpeed = 15;

    [Header("Jump")]
    public float jumpHeight = 3;
    public float gravityIntensity = -15;

    [Header("Falling")]
    public float inAirTimer;
    public float leapingVelocity;
    public float fallingSpeed;

    [Header("Ground Check")]
    public bool isGrounded;
    public LayerMask whatIsGround;
    public float playerHeight = 3.6f;

    [Header("Earth Ability")]
    public LayerMask validEarth;
    public bool canSummonEarth;
    Vector3 lookDirection;
    public GameObject summonPoint;
    public SummonEarth summonEarth;

    [Header("Old Double Jump")]
    public bool doubleJump;
    public bool readyToJump;
    public bool hasJumped;
    public float jumpBoost = 1;

    void Awake()
    {
        inputManager = GetComponent<InputManager>();
        playerRigidbody = GetComponent<Rigidbody>();
        cameraObject = Camera.main.transform;
        animatorManager = GetComponent<AnimatorManager>();
        playerCapsule = GetComponent<CapsuleCollider>();
    }

    private void Update()
    {
        isGrounded = Physics.Raycast(playerCapsule.transform.position, Vector3.down, 0.1f, whatIsGround);
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
        if (!isGrounded && !isJumping)
        {
            inAirTimer = inAirTimer + Time.deltaTime;
            playerRigidbody.AddForce(transform.forward * leapingVelocity);
            playerRigidbody.AddForce(Vector3.down * fallingSpeed);
        }

        if (isGrounded)
        {
            inAirTimer = 0;
            animatorManager.animator.SetBool("isJumping", false);
        }
    }

    public void OldHandleJumping()
    {
        if (isGrounded || doubleJump)
        {
            if (hasJumped)
            {
                doubleJump = false;
            }

            playerRigidbody.AddForce(new Vector3(0, jumpHeight * 2 * playerHeight * jumpBoost, 0), ForceMode.Impulse);
            Invoke("StopJump", 1);
        }
    }

    public void HandleJumping()
    {
        Debug.Log("Jump Recieve");

        if (isGrounded)
        {
            Debug.Log("Jump Activate");
            //animatorManager.animator.SetBool("isJumping", true);

            #region Stand In Jump
            isJumping = true;
            playerRigidbody.AddForce(new Vector3(0, jumpHeight * 2 * playerHeight * jumpBoost, 0), ForceMode.Impulse);
            Invoke("StopJump", 2);
            #endregion

            #region Actual Jump
            //float jumpingVelocity = Mathf.Sqrt(-2 * gravityIntensity * jumpHeight);
            //Vector3 playerVelocity = moveDirection;
            //playerVelocity.y = jumpingVelocity;
            //playerRigidbody.velocity = playerVelocity;
            //animatorManager.PlayTargetAnimation("Jump", false);
            #endregion
        }
    }

    void StopJump()
    {
        hasJumped = true;
        isJumping = false;
        readyToJump = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    private void OnCollisionExit(Collision collision)
    {
        jumpBoost = 1;
    }

    public void OldEarthActivate()
    {
        Debug.Log("Earth Recieved");

        RaycastHit hit;
        canSummonEarth = Physics.Raycast(transform.position, Vector3.forward, out hit, 5f, validEarth);

        if (canSummonEarth)
        {
            Debug.Log("Earth Activate");
            Vector3 relocate = hit.transform.position;
            summonPoint.transform.position = relocate;
            summonEarth.ActivateAbility();
        }
    }

    public void OnTriggerEnter(Collider trigger)
    {
        if (trigger.GetComponent<Collider>().tag == "validEarth")
        {
            canSummonEarth = true;
        }

        if (trigger.GetComponent<Collider>().tag == "boost")
        {
            jumpBoost = 5;
        }
    }

    public void OnTriggerExit(Collider trigger)
    {
        if (trigger.GetComponent<Collider>().tag == "validEarth")
        {
            canSummonEarth = false;
        }

        if (trigger.GetComponent<Collider>().tag == "boost")
        {
            jumpBoost = 1;
        }
    }

    public void EarthActivate()
    {
       Debug.Log("Earth Recieved");

       if (canSummonEarth)
        {
            Debug.Log("Hit");
			//summonPoint.transform.position = hit.transform.position;
            summonEarth.ActivateAbility();
		}
	}
}
