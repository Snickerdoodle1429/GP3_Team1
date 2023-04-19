using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinside : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 20f * Time.deltaTime, 0f);
    }
}
