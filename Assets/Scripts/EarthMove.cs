using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthMove : MonoBehaviour
{
    public float timeElapsed;
    public float moveDuration = 5;
    public float moveValue = 10;

    public bool inPlace;
    Vector3 endPosition;

    public GameObject earthChunk;
    Rigidbody earthRigid;

    private void Start()
	{
        endPosition = transform.position;
        earthRigid = GetComponent<Rigidbody>();
        Physics.IgnoreLayerCollision(6, 7);
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
        Invoke("EarthFall", moveDuration);
    }

    void EarthFall()
    {
		StartCoroutine(MoveEarth(endPosition));
        Destroy(gameObject, moveDuration);
	}
}
