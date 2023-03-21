using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBallBehaviour : MonoBehaviour
{
    public float force = 2;

    [SerializeField]
    private bool otherBallCollided = false;

    //[SerializeField]
    //private List<GameObject> gameObjectsInRedBallZone = new();

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (otherBallCollided)
        {
            rb.velocity = Vector2.zero;
            
            Collider2D[] gameObjectsInRedBallZone = Physics2D.OverlapCircleAll(this.transform.position, 1.5f);

            foreach (var item in gameObjectsInRedBallZone)
            {
                item.GetComponent<Rigidbody2D>().AddForce(item.transform.position - this.transform.position * force, ForceMode2D.Impulse);
            }
            otherBallCollided = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsInList(collision.gameObject, GlobalBalls.balls))
        {
            otherBallCollided = true;
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (IsInList(collision.gameObject, GlobalBalls.balls))
    //    {
    //        gameObjectsInRedBallZone.Add(collision.gameObject);
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    gameObjectsInRedBallZone.Remove(collision.gameObject);
    //}

    bool IsInList(GameObject objectToFind, List<GameObject> listOfObject)
    {
        foreach (var item in listOfObject)
        {
            if (item == objectToFind)
            {
                return true;
            }
        }
        return false;
    }
}
