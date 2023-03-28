using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonEarth : MonoBehaviour
{
    public GameObject cubePrefab;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            Instantiate(cubePrefab, transform.position, Quaternion.identity);
		}
    }
}
