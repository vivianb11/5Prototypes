using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class PlayerCollision : MonoBehaviour, IDestructable
{
    public GameObject particules;

    public void Destroy()
    {
        StartCoroutine(DestroyAnimation());
    }

    IEnumerator DestroyAnimation()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<PlayerShoot>().enabled = false;
        gameObject.GetComponent<PlayerMovement>().enabled = false;
        gameObject.GetComponent<PolygonCollider2D>().enabled = false;


        GameObject justSpawned;
        justSpawned = Instantiate(particules, this.transform);
        yield return new WaitForSeconds(justSpawned.GetComponent<ParticleSystem>().main.duration);
        Destroy(justSpawned);
        yield return new WaitForSeconds(1f);
        EditorSceneManager.LoadScene(0);
    }
}
