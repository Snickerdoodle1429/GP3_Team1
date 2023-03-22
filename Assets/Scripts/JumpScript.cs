using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScript : MonoBehaviour
{
    public Rigidbody rb;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	private void Update()
	{
		//if ()
		{
			//rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
		}
	}
}
