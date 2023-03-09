using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBallBehaviour : MonoBehaviour
{
    public Black bBall;
    public Rigidbody2D rb;

    [Range(10,100)]
    public int chargePercent;

    public float timeBetweenCharge = 5;

    private bool coroutinStarted = false;
    private bool ballColided = false;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        bBall = new(this.gameObject, chargePercent);
    }

    private void Update()
    {
        if (!coroutinStarted && !ballColided)
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

        bBall.BallMovement(timeBetweenCharge);

        yield return wait;
        coroutinStarted = false;
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
    Rigidbody2D rb;
    GameObject go;
    Transform player;

    int chargePercent;

    public Black(GameObject bGO, int timeToChargeAttaque)
    {
        go = bGO;
        rb = go.GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").transform;
        chargePercent = timeToChargeAttaque;
    }

    public override void BallAbility()
    {
        throw new System.NotImplementedException();
    }

    public override void BallVFX(int number)
    {
        throw new System.NotImplementedException();
    }

    public override IEnumerator BallMovement(float time)
    {
        WaitForSeconds wait1 = new(time / chargePercent);
        WaitForSeconds wait2 = new(time - time / chargePercent);
        Debug.Log("Wait 1 start");
        yield return wait1;
        Debug.Log("Wait 2 start");
        yield return wait2;
    }
}
