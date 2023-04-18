using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bouncer : MonoBehaviour
{
    public Transform startMarkerOne;
    public Transform endMarkerOne;

    public float speed = 1.0f;
    private float startTime;
    private float journeyLength;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        journeyLength = Vector3.Distance(startMarkerOne.position, endMarkerOne.position);
    }

    // Update is called once per frame
    void Update()
    {
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered/journeyLength;
        transform.position = Vector3.Lerp(startMarkerOne. position, endMarkerOne.position, Mathf.PingPong(fracJourney, 1));
    }
}
