using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Return : MonoBehaviour, ITurnAction
{
    public Vector3Variable HomePosition;

    public float speed = 5f;

    public bool IsDone { get; set; }

    private void Start()
    {
        StartCoroutine(MoveToTarget());

    }

    public void Move()
    {
        IsDone = false;
        StartCoroutine(MoveToTarget());
    }

    IEnumerator MoveToTarget()
    {
        // Check if the target position is not null
        if (HomePosition != null)
        {
            // Calculate the distance between the current position and the target position
            float distance = Vector3.Distance(transform.position, HomePosition.Value);

            // Check if the distance is greater than a small value to avoid jittering
            while (distance > 0.1f)
            {
                // Use Lerp to smoothly interpolate between the current position and the target position
                transform.position = Vector3.MoveTowards(transform.position, HomePosition.Value, speed * Time.deltaTime);
                distance = Vector3.Distance(transform.position, HomePosition.Value );
                yield return new WaitForEndOfFrame();
            }
        }
        IsDone = true;
        yield return null;
    }

    public void Execute()
    {
        Move();
    }
}
