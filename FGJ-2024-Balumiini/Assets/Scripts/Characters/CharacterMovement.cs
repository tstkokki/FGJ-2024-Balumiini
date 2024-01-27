using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterMovement : MonoBehaviour, ITurnAction
{
    public Vector3 HomePosition;
    public Vector3Variable TargetPosition;

    public float speed = 1f;

    public bool IsDone { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        HomePosition = transform.position;
    }

    public void Move()
    {
        IsDone= false;
        StartCoroutine(MoveToTarget());
    }

    IEnumerator MoveToTarget()
    {
        // Check if the target position is not null
        if (TargetPosition != null)
        {
            // Calculate the distance between the current position and the target position
            float distance = Vector3.Distance(transform.position, TargetPosition.Value);
            
            // Check if the distance is greater than a small value to avoid jittering
            while (distance > 2f)
            {
                // Use Lerp to smoothly interpolate between the current position and the target position
                transform.position = Vector3.Lerp(transform.position, TargetPosition.Value, speed * Time.deltaTime);
                distance = Vector3.Distance(transform.position, TargetPosition.Value);
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
