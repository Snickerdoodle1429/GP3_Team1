using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    #region Variables
    PlayerControls playerControls;
    PlayerMovement playerMovement;
    AnimatorManager animatorManager;
    PausedMenu pausedMenu;

    public Vector2 movementInput;
    public Vector2 cameraInput;

    public float cameraInputX;
    public float cameraInputY;

    public float moveAmount;
    public float verticalInput;
    public float horizontalInput;

    public bool sprintKey;
    public bool jumpKey;
    public bool pauseKey;
    public bool skipKey;

    public AudioSource audiosource;
    #endregion

    #region Manage
    private void Awake()
	{
        animatorManager = GetComponent<AnimatorManager>();
        pausedMenu = FindObjectOfType<PausedMenu>();
	}

	void OnEnable()
    {
        if(playerControls == null)
        {
            playerControls = new PlayerControls();
            playerMovement = GetComponent<PlayerMovement>();

            playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
            playerControls.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();

            playerControls.PlayerActions.Sprint.performed += i => sprintKey = true;
            playerControls.PlayerActions.Sprint.canceled += i => sprintKey = false;

			playerControls.PlayerActions.Jump.performed += i => jumpKey= true;
			playerControls.PlayerActions.Jump.canceled += i => jumpKey = false;

			playerControls.PlayerActions.Pause.performed += i => pauseKey = true;
			playerControls.PlayerActions.Pause.canceled += i => pauseKey = false;

			playerControls.PlayerActions.Skip.performed += i => skipKey = true;
			playerControls.PlayerActions.Skip.canceled += i => skipKey = false;
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
        HandlePause();
	}
    #endregion

    #region Move
    void HandleMovementInput()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;

        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
        animatorManager.UpdateAnimatorValues(0, moveAmount, playerMovement.isSprinting);

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
            Debug.Log("Jump Sent");
            playerMovement.HandleJumping();
            animatorManager.animator.SetBool("isJumping", true);
			jumpKey = false;
		}
    }
    #endregion

    #region Menus
    void HandlePause()
    {
        if (pauseKey)
        {
            Debug.Log("Pausing...");
            pausedMenu.PauseButton();
            pauseKey = false;
        }
    }
    #endregion
}
