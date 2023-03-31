using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceFromCameraBounds : MonoBehaviour
{
    public Camera mainCamera;

    public float offset = 1;

    public float distance;
    public float offsetedDistance;

    RaycastHit2D ray;

    private void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    private void Update()
    {
        ray = Physics2D.Raycast(mainCamera.transform.position, -transform.up);

        distance = Vector2.Distance(ray.point, this.transform.position);

        offsetedDistance = distance - offset;
    }

}