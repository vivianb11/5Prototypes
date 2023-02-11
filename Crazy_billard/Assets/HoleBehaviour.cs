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
            //Event.current;
        }
        else
        {
            Action(collision.tag, collision.gameObject);
        }
    }

    void Action(string type, GameObject collider)
    {
        if (type == "Black")
        {
            GameOver();
        }
        else
        {
            print("hello");

            collider.transform.DOScale(0,1);
            collider.GetComponent<SpriteRenderer>().DOFade(0,1).OnComplete(() => { Destroy(collider); });
        }
    }

    void GameOver()
    {
        StartCoroutine(nameof(StartGameOver));
    }

    IEnumerator StartGameOver()
    {
        WaitForSeconds waitTime = new(5f);
        yield return waitTime;
    }
}
