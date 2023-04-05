using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public SceneReloader restart;

    RaycastHit2D ray;

    private void Start()
    {
            restart = GameObject.Find("GameManager").GetComponent<SceneReloader>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision?.name == "Player")
        {
            ray = Physics2D.Raycast(this.transform.position, (collision.transform.position - this.transform.position).normalized);

            if (ray.collider.gameObject.name == "Player")
            {
                restart.GameOver();
            }
        }
    }
}
