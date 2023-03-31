using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{

    public float speed = 5f;
    private Rigidbody2D rb;

    public float timeBeforDespawn = 10;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;
        StartCoroutine(DespawnAfter());
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IDestructable destructable = collision.gameObject.GetComponent<IDestructable>();
        if (collision.collider.name != "Player")
        {
            if (destructable != null)
            {
                destructable.Destroy();
            }
            Destroy(gameObject);
        }
    }

    IEnumerator DespawnAfter()
    {
        yield return new WaitForSeconds(timeBeforDespawn);
        Destroy(gameObject);
    }
}
