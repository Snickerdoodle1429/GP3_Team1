using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthMove : MonoBehaviour
{
    public float timeElapsed;
    public float moveDuration = 3;
    public float moveValue = 3;

    public bool inPlace;
    Vector3 endPosition;

    public GameObject earthChunk;

	private void Start()
	{
        endPosition = transform.position;
        EarthAbility();
	}

	void EarthAbility()
    {
        StopAllCoroutines();
        
        Vector3 activePostion = endPosition + Vector3.up * moveValue;
        StartCoroutine(MoveEarth(activePostion));
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
        Invoke("EarthFall", 3);
    }

    void EarthFall()
    {
		StartCoroutine(MoveEarth(endPosition));
        Destroy(gameObject, moveDuration + 0.5f);
	}
}
