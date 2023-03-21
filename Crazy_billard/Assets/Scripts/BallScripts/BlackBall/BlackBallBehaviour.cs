using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBallBehaviour : MonoBehaviour
{
    public Black bBall;
    public Rigidbody2D rb;

    [Header("Attaque Patern")]
    [Range(10,100)]
    public int chargePercent;

    public float timeBetweenCharge = 5;

    private bool coroutinStarted = false;
    private bool ballColided = false;

    private void Awake()
    {
        bBall = new(this.gameObject);
        GlobalBalls.cBall.Add(bBall);
    }
    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!coroutinStarted && !ballColided && rb.velocity.magnitude <= 0.1f && !bBall.ballRespawn)
        {
            StartCoroutine(StartBallBehavior());
        }
        if (ballColided && rb.velocity.magnitude <= 1)
        {
            ballColided = false;
        }
    }

    IEnumerator StartBallBehavior()
    {
        WaitForSeconds wait = new(timeBetweenCharge);
        coroutinStarted = true;

        StartCoroutine(BallMovement());

        yield return wait;
        coroutinStarted = false;
    }

    public IEnumerator BallMovement()
    {
        WaitForSeconds wait1 = new(timeBetweenCharge * chargePercent/100);
        WaitForSeconds wait2 = new(timeBetweenCharge - timeBetweenCharge * chargePercent/100);

        bBall.BallMovement(1);
        yield return wait1;

        bBall.BallMovement(2);
        yield return wait2;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ballColided = true;
        }
    }

    private void OnEnable()
    {
        coroutinStarted = false;
    }

    private void OnDisable()
    {
        coroutinStarted = true;
    }
}

public class Black : BallClass
{
    public bool ballRespawn;

    Rigidbody2D rb;
    GameObject go;
    Transform player;
    Vector2 playerDirection;

    public Black(GameObject bGO)
    {
        go = bGO;
        rb = go.GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").transform;
        ballRespawn = false;
    }

    public override void BallAbility()
    {
        throw new System.NotImplementedException();
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
