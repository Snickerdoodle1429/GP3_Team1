using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    PlayerControls playerControls;
    PlayerMovement playerMovement;
    AnimatorManager animatorManager;

    public Vector2 movementInput;
    public Vector2 cameraInput;

    public float cameraInputX;
    public float cameraInputY;

    public float moveAmount;
    public float verticalInput;
    public float horizontalInput;

    public bool sprintKey;
    public bool jumpKey;

    public bool earthKey;

	private void Awake()
	{
        animatorManager = GetComponent<AnimatorManager>();
	}

	void OnEnable()
    {
        if(playerControls == null)
        {
            playerControls = new PlayerControls();
            playerMovement = GetComponent<PlayerMovement>();

            playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
            playerControls.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();

            playerControls.PlayerActions.B.performed += i => sprintKey = true;
            playerControls.PlayerActions.B.canceled += i => sprintKey = false;

			playerControls.PlayerActions.Jump.performed += i => jumpKey= true;
			playerControls.PlayerActions.Jump.canceled += i => jumpKey = false;

			playerControls.PlayerActions.Earth.performed += i => earthKey = true;
			playerControls.PlayerActions.Earth.canceled += i => earthKey = false;
		}

        playerControls.Enable();
    }

    void OnDisable()
    {
        playerControls.Disable();
    }

    public void HandleAllInputs()
    {
        HandleMovementInput();
        HandleSprintingInput();
        HandleJumpingInput();
        HandleEarthAbility();
	}

	void HandleMovementInput()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;

        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
        animatorManager.UpdateAnimatorValues(0, moveAmount);

		cameraInputY = cameraInput.y;
        cameraInputX = cameraInput.x;
    }

	void HandleSprintingInput()
	{
		if (sprintKey)
        {
            playerMovement.isSprinting = true;
        }
        else
        {
            playerMovement.isSprinting = false;
        }
	}

    void HandleJumpingInput()
    {
        if (jumpKey)
        {
            playerMovement.HandleJumping();
        }
    }

    void HandleEarthAbility()
    {
        if (earthKey)
        {
            Debug.Log("Sent");
            playerMovement.EarthActivate();
        }
    }
}
