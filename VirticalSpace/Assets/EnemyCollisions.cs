using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisions : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        IDestructable destructable = collision.gameObject.GetComponent<IDestructable>();

        if (collision.collider.name == "Player")
        {
            if (destructable != null)
            {
                destructable.Destroy();
            }
            Destroy(gameObject);
        }
    }
}
