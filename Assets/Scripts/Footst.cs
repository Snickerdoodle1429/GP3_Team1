using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footst : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public InputManager inputManager;

    public AudioSource feet;
    public AudioClip walking;
    public AudioClip sprinting;

    void Update()
    {
        if (playerMovement.isSprinting)
        {
            feet.clip = sprinting;
            feet.Play();
        }
        else if (inputManager.moveAmount !> 0f)
        {
            feet.clip = walking;
        }
        else
        {
            feet.Stop();
        }
    }
}
