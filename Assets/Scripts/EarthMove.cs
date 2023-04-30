using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthMove : MonoBehaviour
{
    #region Variables
    public float timeElapsed;
    public float moveDuration = 3;
    public float moveValue = 3;
    public int delay = 2;

    public bool inPlace;
    Vector3 endPosition;

    public GameObject earthChunk;
    Rigidbody earthRigid;

    public AudioClip platform;
    #endregion

    private void Start()
	{
        AudioSource audio = GetComponent<AudioSource>();

        endPosition = transform.position;
        earthRigid = GetComponent<Rigidbody>();
        Physics.IgnoreLayerCollision(0, 0, true);
        Physics.IgnoreLayerCollision(6, 7, true);
        Invoke("EarthAbility", delay);
    }

	void EarthAbility()
    {
        EarthSound();
        StopAllCoroutines();
        
        Vector3 activePostion = endPosition + Vector3.down * moveValue;
        StartCoroutine(MoveEarth(activePostion));
    }

    void EarthSound()
    {
        GetComponent<AudioSource>().clip = platform;
        GetComponent<AudioSource>().Play();
    }

    IEnumerator MoveEarth(Vector3 targetPosition)
    {
        float timeElapsed = 0;
        Vector3 startPosition = transform.position;

        while (timeElapsed < moveDuration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, timeElapsed / moveDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
        EarthFall();
    }

    void EarthFall()
    {
        EarthSound();
		StartCoroutine(MoveEarth(endPosition));
        Invoke("EarthAbility",moveDuration);
	}
}
