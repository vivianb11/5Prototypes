using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 endPoint;

    public LineRenderer lR;

    public float force = 2;

    private Rigidbody2D rb;

    public List<Collider2D> col;

    RaycastHit2D hit;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lR = GetComponentInChildren<LineRenderer>();
    }

    private void OnMouseDrag()
    {
        lR.enabled = true;
        lR.SetPosition(0,(Vector2)this.transform.position);
        lR.startWidth = 0.075f;
        lR.endWidth = 0.1f;
        lR.SetPosition(1, (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }

    private void OnMouseUp()
    {
        lR.enabled = false;
        endPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = ((Vector2)this.transform.position - endPoint).normalized;

        //SwitchColliders(false);

        
        hit = Physics2D.CircleCast((Vector2)this.transform.position,0.5f, direction);

        //SwitchColliders(true);

        if (hit.collider.name == "PurpleBall" || !hit)
        {
            hit.collider.GetComponent<PurpleBallBehaviour>().pBall.TpCondition(hit.normal);
        }

        rb.AddForce(direction * Vector2.Distance(this.transform.position,endPoint) * force, ForceMode2D.Impulse);
    }


    void SwitchColliders(bool yn)
    {
        foreach (var item in col)
        {
            item.enabled = yn;
        }
    }
}
