using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    //public delegate void ShakeCam();
    //public static event ShakeCam OnPlayerColide;

    private Vector2 startPoint;
    private Vector2 endPoint;

    public float force = 2;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnMouseDown()
    {
        print(1);
        startPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseUp()
    {
        print(2);
        endPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (startPoint - endPoint).normalized;
        rb.AddForce(direction * Vector2.Distance(startPoint,endPoint) * force, ForceMode2D.Impulse);
    }

    //public void OnCollisionEnter2D(Collision2D collision)
    //{
    //    OnPlayerColide();
    //}
}
