using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePrefab : MonoBehaviour
{
    public float life = 2;

	private void Awake()
	{
		Destroy(gameObject, life);
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.GetComponent<GameObject>().tag != "Player")
		{
			collision.gameObject.SetActive(false);
			Destroy(gameObject);
		}
	}
}
