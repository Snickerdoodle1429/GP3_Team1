using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTest : MonoBehaviour
{
    #region Variables
    public float timeElapsed;
    public float moveDuration = 2;
    public float moveValue = 5;

    Rigidbody playerRigid;
    #endregion

    private void Start()
    {
        playerRigid = GetComponent<Rigidbody>();
    }

    public void SendJump()
    {
        Invoke("JumpAbility", 0.75f);
    }

    public void JumpAbility()
    {
        Debug.Log("Recieve Jump");
        StopAllCoroutines();

        Vector3 activePostion = transform.position + Vector3.up * moveValue;
        StartCoroutine(Jump(activePostion));
    }

    IEnumerator Jump(Vector3 targetPosition)
    {
        Debug.Log("StartJump");

        float timeElapsed = 0;
        Vector3 startPosition = transform.position;

        while (timeElapsed < moveDuration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, timeElapsed / moveDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
    }
}