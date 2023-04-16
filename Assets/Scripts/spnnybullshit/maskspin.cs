using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maskspin : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 100f * Time.deltaTime, 0f);
    }
}
