using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
	public GameObject respawnPoint;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.GetComponent<Collider>().tag == "RespawnPoint")
		{
			Debug.Log("Spawnpoint: " + transform.position);
			respawnPoint.transform.position = transform.position;
			other.gameObject.SetActive(false);
		}
	}
}
