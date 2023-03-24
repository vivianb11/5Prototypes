using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;    // Player movement speed
    public float rotationSpeed = 200f;  // Player rotation speed

    private Rigidbody2D rb;         // Player rigidbody component
    private Camera mainCamera;      // Main camera

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Get player input
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        // Move player based on input
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb.velocity = movement.normalized * moveSpeed;

        // Rotate player to face mouse position
        Vector2 targetPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        
        float angle = Mathf.Atan2(transform.position.y - targetPos.y, transform.position.x - targetPos.x) * Mathf.Rad2Deg;

        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}