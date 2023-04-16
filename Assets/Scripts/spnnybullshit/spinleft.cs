using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinleft : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
         transform.Rotate(0f, 0f, -125f * Time.deltaTime);
    }
}
