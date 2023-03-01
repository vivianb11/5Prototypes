using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnCollisionEvent : MonoBehaviour
{
    public List<string> whenToShake;

    public UnityEvent OnCollision;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (var item in whenToShake)
        {
            if (collision.gameObject.CompareTag(item))
            {
                OnCollision?.Invoke();
            }
        }
    }
}
