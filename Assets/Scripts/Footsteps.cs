using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Footsteps : MonoBehaviour
{
    public AudioSource walking, sprintSound;

    void Update()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)){
            if (Input.GetKey(KeyCode.LeftShift))
            {
                walking.enabled = false;
                sprintSound.enabled = true;
            }
            else
            {
                walking.enabled = true;
                sprintSound.enabled = false;
            }
        }
        else
        {
            walking.enabled = false;
            sprintSound.enabled = false;
        }
    }
}
