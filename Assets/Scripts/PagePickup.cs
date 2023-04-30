using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PagePickup : MonoBehaviour
{
    public AudioClip pageChime;

    private void Start()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.playOnAwake = false;
        audio.clip = pageChime;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Rigidbody>().tag == "Player")
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
