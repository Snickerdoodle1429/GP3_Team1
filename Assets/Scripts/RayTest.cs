using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, Vector3.forward, out hit, 100.0f))
            {
                Debug.Log("Object distance: " + hit.distance);
            }
        }
    }
}
