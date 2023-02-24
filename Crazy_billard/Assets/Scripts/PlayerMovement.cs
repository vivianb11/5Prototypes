using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 startPoint;
    private Vector2 endPoint;

    public LineRenderer lR;

    public float force = 2;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lR = GetComponentInChildren<LineRenderer>();
    }

    //private void OnMouseDown()
    //{
    //    startPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //}

    private void OnMouseDrag()
    {
        lR.enabled = true;
        lR.SetPosition(0,(Vector2)this.transform.position);
        lR.startWidth = 0.05f;
        lR.endWidth = 0.1f;
        lR.SetPosition(1, (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }

    private void OnMouseUp()
    {
        lR.enabled = false;
        endPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = ((Vector2)this.transform.position - endPoint).normalized;
        rb.AddForce(direction * Vector2.Distance(startPoint,endPoint) * force, ForceMode2D.Impulse);
    }
}
