using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class HoleBehaviour : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // collision.GetComponent<PlayerMovement>().enabled = false;
            foreach (var item in GlobalBalls.cBall)
            {
                item.ballRespawn =true;
            }
            collision.GetComponent<Respawn>().RespawnBall();
        }
        else
        {
            Action(collision.tag, collision.gameObject);
        }
    }

    void Action(string type, GameObject collider)
    {
        if (type == "Black" && GlobalBalls.ballNumber > 1)
        {
            GameOver();
        }
        else
        {
            collider.transform.DOMove(this.transform.position,1);
            collider.transform.DOScale(0,1);
            collider.GetComponent<SpriteRenderer>().DOFade(0, 1).OnComplete(() =>
            {
                if (collider)
                {
                    Destroy(collider);
                }
            });
        }
    }

    void GameOver()
    {
        StartCoroutine(nameof(StartGameOver));
    }

    IEnumerator StartGameOver()
    {
        WaitForSeconds waitTime = new(1f);
        print("Game Over");
        yield return waitTime;
    }
}
