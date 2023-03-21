using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
                item.ChangeVariable(true);
            }
            collision.GetComponent<Respawn>().RespawnBall();
        }
        else
        {
            Action(collision.name, collision.gameObject);
        }
    }

    async void Action(string name, GameObject collider)
    {
        if (name == "BlackBall" && GlobalBalls.ballNumber > 1)
        {
            GameOver();
        }
        else
        {
            collider.transform.DOScale(0,1);
            collider.transform.DOMove(this.transform.position,1);
            await collider.GetComponent<SpriteRenderer>().DOFade(0, 1).AsyncWaitForCompletion();
            
            if (collider)
            {
                collider.SetActive(false);
                collider.transform.position = new(0, 15);
                collider.transform.DOScale(1,0);
                collider.GetComponent<SpriteRenderer>().DOFade(1, 0);
            }
        }
    }

    void GameOver()
    {
        Debug.Log("GameOver Detected");

        StartCoroutine(nameof(StartGameOver));
    }

    IEnumerator StartGameOver()
    {
        WaitForSeconds waitTime = new(1f);

        Debug.Log("GameOver");
        yield return waitTime;

        SceneManager.LoadScene(0);
    }
}
