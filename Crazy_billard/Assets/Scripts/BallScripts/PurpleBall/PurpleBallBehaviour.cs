using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleBallBehaviour : MonoBehaviour
{
    public Purple pBall;
    public Rigidbody2D rb;

    private void Awake()
    {
        pBall = new(this.gameObject);
        GlobalBalls.cBall.Add(pBall);
    }
    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }
}

public class Purple : BallClass
{
    public bool ballRespawn;

    Rigidbody2D rb;
    GameObject go;
    Transform player;
    Vector2 playerDirection;


    public Purple(GameObject ballGO)
    {
        go = ballGO;
        rb = go.GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").transform;
        ballRespawn = false;
    }

    public override void BallAbility()
    {
        throw new System.NotImplementedException();
    }
    public void TpCondition(Vector2 normal)
    {
        RaycastHit2D hit = Physics2D.Raycast(go.transform.position, -1 * normal);

        if (!hit || hit.collider.gameObject.layer == 6)
        {
            Vector2 respawnPlace = PlaceRandomizer(9f,3f);

            go.transform.position = respawnPlace;
        }
    }

    Vector2 PlaceRandomizer(float x, float y)
    {
        Vector2 place = new(Random.Range(- x, x), Random.Range(-y, y));

        return place;
    }

    public override void BallMovement(int AbilityNumber)
    {
        if (AbilityNumber == 1)
        {
            playerDirection = (player.position - go.transform.position).normalized;
            rb.AddForce(- playerDirection, ForceMode2D.Impulse);
        }
        if (AbilityNumber == 2)
        {
            rb.AddForce(playerDirection * 20, ForceMode2D.Impulse);
        }
    }

    public override void BallVFX(int number)
    {
        throw new System.NotImplementedException();
    }

    public override void ChangeVariable(bool state)
    {
        ballRespawn = state;
    }
}
