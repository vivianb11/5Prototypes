using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    private bool instantiateSpawn;

    private Vector2 ballPosition;

    private Rigidbody2D rb;
    private Collider2D col;

   public void RespawnBall()
    {
        instantiateSpawn = true;
        rb = this.GetComponent<Rigidbody2D>();
        col = this.GetComponent<Collider2D>();
        col.enabled = false;
    }

    private void Update()
    {
        if (instantiateSpawn)
        {
            ballPosition.x = Mathf.Clamp(((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition)).x, -9.4f, 9.4f);
            ballPosition.y = Mathf.Clamp(((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition)).y, -3.45f, 3.45f);

            this.transform.position = ballPosition;

            if (Input.GetMouseButtonDown(0))
            {
                foreach (var item in GlobalBalls.cBall)
                {
                    item.ballRespawn = false;
                }
                col.enabled = true;
                rb.velocity = Vector2.zero;
                instantiateSpawn = false;
            }
        }
    }
}
