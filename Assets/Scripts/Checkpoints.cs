using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
	public GameObject respawnPoint;
	public AudioClip checkpoint;

	private void Start()
	{
        AudioSource audio = GetComponent<AudioSource>();
		audio.playOnAwake = false;
		audio.clip = checkpoint;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.GetComponent<Collider>().tag == "Player")
		{
			Debug.Log("Spawnpoint: " + transform.position);

			GetComponent<AudioSource>().Play();

			respawnPoint.transform.position = transform.position;
			gameObject.SetActive(false);
		}
	}
}
