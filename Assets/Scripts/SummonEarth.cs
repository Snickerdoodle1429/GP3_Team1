using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonEarth : MonoBehaviour
{
    public GameObject cubePrefab;

    public void ActivateAbility()
    {
        Debug.Log("Activated");
        Instantiate(cubePrefab, transform.position, Quaternion.identity);
    }
}
