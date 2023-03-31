using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DirectionMovement : MonoBehaviour
{
    public float rotationStep = 10f; // how much to rotate object by when Q or E is pressed
    public float maxRotationAngle = 90f; // maximum angle object can be rotated on z-axis

    private bool isRotating = false; // flag to keep track of whether object is currently rotating
    private float currentRotationAngle = 0f; // current angle object is rotated on z-axis

    public Camera cam;

    void Update()
    {
        // check for Q or E key presses
        if (Input.GetKeyDown(KeyCode.A) && !isRotating)
        {
            RotateObject(1); // rotate object left
        }
        else if (Input.GetKeyDown(KeyCode.D) && !isRotating)
        {
            RotateObject(-1); // rotate object right
        }
    }

    void RotateObject(int direction)
    {
        isRotating = true;

        // calculate target angle based on direction of rotation
        float targetRotationAngle = currentRotationAngle + (direction * rotationStep);

        // check if target angle is within allowed range
        if (Mathf.Abs(targetRotationAngle) <= maxRotationAngle)
        {
            currentRotationAngle = targetRotationAngle;
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, currentRotationAngle);
        }

        isRotating = false;
    }
}
