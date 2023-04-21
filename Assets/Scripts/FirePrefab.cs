using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePrefab : MonoBehaviour
{
    public float life = 1;

	private void Awake()
	{
		Destroy(gameObject, life);
		Debug.Log("Fire Summoned");
	}

	private void OnTriggerEnter(Collider collision)
	{
		if (collision.gameObject.GetComponent<Collider>().tag == "firecollide")
		{
			if (collision != null)
			{
				Debug.Log("Fire Collided");
				FireActivate fireActivate = collision.GetComponent<FireActivate>();
				fireActivate.FireActive();
			}
		}
	}
}
