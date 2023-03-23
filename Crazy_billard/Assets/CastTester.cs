using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastTester : MonoBehaviour
{
    RaycastHit2D hit1;
    RaycastHit2D hit2;

    public GameObject purpelBall;

    void Update()
    {
        Vector2 direction = (Vector2)purpelBall.transform.position - (Vector2)this.transform.position;

        hit1 = Physics2D.CircleCast(this.transform.position, 0.5f, direction);

        hit2 = Physics2D.Raycast(purpelBall.transform.position, -hit1.normal);

        if (hit2.collider.name == "Hole")
        {
            Debug.DrawRay(purpelBall.transform.position, -hit1.normal, Color.green);
        }
        else
        {
            Debug.DrawRay(purpelBall.transform.position, -hit1.normal, Color.red);
        }
        Debug.Log(hit2.collider.name);

    }
}
