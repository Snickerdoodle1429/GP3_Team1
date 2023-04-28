using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireActivate : MonoBehaviour
{
    public GameObject fiyah;

    void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Rigidbody>().tag == "Player")
        {
            fiyah.SetActive(true);
        }
    }
}
