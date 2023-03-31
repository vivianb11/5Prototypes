using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionBehaviour : MonoBehaviour
{
    public PlayerSpawnIfNoEnnemies playerSpawnIfNoEnnemies;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            playerSpawnIfNoEnnemies.enabled = false;
            StartCoroutine(DetructionProtocol(collision.gameObject));
        }
    }

    IEnumerator DetructionProtocol(GameObject who)
    {
        GameObject toSpawn = who.GetComponent<ChangeData>().GivePlayableEnemy();

        Vector3 whereToSpawn = who.transform.position;

        Destroy(who);
        yield return new WaitForEndOfFrame();
        Instantiate(toSpawn, whereToSpawn,Quaternion.identity);


        Destroy(gameObject);
    }
}
