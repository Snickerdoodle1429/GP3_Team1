using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maskspin : MonoBehaviour
{
    public int spinSpeed = 100;

    void Update()
    {
        transform.Rotate(0f, spinSpeed * Time.deltaTime, 0f);
    }
}
