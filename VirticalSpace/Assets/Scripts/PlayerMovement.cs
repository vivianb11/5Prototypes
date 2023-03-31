using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1f;

    public DistanceFromCameraBounds distanceFromCameraBounds;

    private float targetHeight;

    void Start()
    { 
        transform.localPosition = Vector3.zero;
    }

    void FixedUpdate()
    {
        float input = Input.GetAxis("Vertical");

        if (input > 0) this.transform.localRotation = Quaternion.Euler(0, 0, 0);
        if (input < 0) this.transform.localRotation = Quaternion.Euler(0, 0, 180);

        targetHeight += input * speed * Time.fixedDeltaTime;
        targetHeight = Mathf.Clamp(targetHeight, - distanceFromCameraBounds.offsetedDistance, distanceFromCameraBounds.offsetedDistance);
        Vector3 newPosition = transform.localPosition;
        newPosition.y = targetHeight;
        transform.localPosition = newPosition;
    }
}

