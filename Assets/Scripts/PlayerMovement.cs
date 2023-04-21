using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    #region Variables
    InputManager inputManager;
    PlayerManager playerManager;
    public AnimatorManager animatorManager;
    public Animator animator;
    Checkpoints checkpoints;
    JumpTest jumpTest;
    public Overall overall;

    private Vector3 moveDirection;
    Transform cameraObject;
    Rigidbody playerRigidbody;
    public Collider playerCapsule;
    public GameObject hubTP;

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
    public int maxJumps = 1;
    public int jumpsRemaining = 0;
    public float jumpBoost = 3;
    public float boostpad = 25;

    [Header("Falling")]
    public float inAirTimer;
    public float leapingVelocity;
    public float fallingSpeed;

    [Header("Ground Check")]
    public bool isGrounded;
    public LayerMask whatIsGround;
    public float playerHeight = 3.6f;

    [Header("Earth Ability")]
    public bool canSummonEarth;
    #endregion

    void Awake()
    {
        inputManager = GetComponent<InputManager>();
        playerRigidbody = GetComponent<Rigidbody>();
        cameraObject = Camera.main.transform;
        animatorManager = GetComponent<AnimatorManager>();
        playerCapsule = GetComponent<CapsuleCollider>();
        checkpoints = GetComponent<Checkpoints>();
        jumpTest = GetComponent<JumpTest>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    #region Movement
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
            playerRigidbody.AddForce(Vector3.down * fallingSpeed * inAirTimer * 2);
        }

        if (isGrounded)
        {
            inAirTimer = 0;
            jumpsRemaining = maxJumps;
            animatorManager.animator.SetBool("isJumping", false);
        }
    }

    public void HandleJumping()
    {
        Debug.Log("Jump Recieve");

        if (jumpsRemaining > 0)
        {
            Debug.Log("Jump Activate");
            isJumping = true;
            jumpsRemaining -= 1;

            animatorManager.animator.SetBool("isJumping", true);

            jumpTest.SendJump();
            Debug.Log("Send Jump");

            Invoke("StopJump", 2);
        }
    }

    void StopJump()
    {
        isJumping = false;
        animatorManager.animator.SetBool("isJumping", false);
    }
    #endregion

    #region Collisions
    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.GetComponent<Collider>().tag == "whatIsGround")
        {
            isGrounded = true;
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.GetComponent<Collider>().tag == "whatIsGround")
        {
            isGrounded = false;
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
            jumpBoost = boostpad;
        }

        if (trigger.GetComponent<Collider>().tag == "mask")
        {
            trigger.gameObject.SetActive(false);
        }

        if (trigger.gameObject.GetComponent<Collider>().tag == "ForceRespawn")
        {
            Debug.Log("Respawn");
            transform.position = checkpoints.respawnPoint.transform.position;
        }

        if (trigger.gameObject.GetComponent<Collider>().tag == "LoadEnd")
        {
            SceneManager.LoadScene("Art Area");

            if(trigger.gameObject.GetComponent<Collider>().name == "Teleport1")
            {
                overall.firstLevel = true;
            }

			if (trigger.gameObject.GetComponent<Collider>().name == "Teleport2")
			{
                overall.secondLevel = true;
			}

			if (trigger.gameObject.GetComponent<Collider>().name == "Teleport3")
			{
                overall.thirdLevel = true;
			}
		}

        if (trigger.gameObject.GetComponent<Collider>().tag == "Level1")
        {
            SceneManager.LoadScene("Water_Level");
        }

        if (trigger.gameObject.GetComponent<Collider>().tag == "Level2")
        {
            SceneManager.LoadScene("Earth_Level");
        }

        if (trigger.gameObject.GetComponent<Collider>().tag == "Level3")
        {
            SceneManager.LoadScene("Fire_Level");
        }

        if (trigger.gameObject.GetComponent<Collider>().tag == "Win")
        {
            SceneManager.LoadScene("Win");
        }

        if (trigger.gameObject.GetComponent<Collider>().tag == "Lose")
        {
            SceneManager.LoadScene("Lose");
        }

        if (trigger.gameObject.GetComponent<Collider>().tag == "Finish")
        {
            Debug.Log("Teleport");
            transform.position = hubTP.transform.position;
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
            jumpBoost = 3;
        }
    }
    #endregion
}
