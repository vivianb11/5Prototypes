using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionBehaviour : MonoBehaviour
{
    public PlayerSpawnIfNoEnnemies playerSpawnIfNoEnnemies;

    public ParticleSystem myParticleSystem;

    private GameObject particulRecever;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            playerSpawnIfNoEnnemies.enabled = false;
            collision.gameObject.GetComponent<Behaviour>().enabled = false;
            this.GetComponent<PlayerMovement>().enabled = false;

            StartCoroutine(DetructionProtocol(collision.gameObject));
        }
    }

    IEnumerator DetructionProtocol(GameObject who)
    {

        GameObject toSpawn = who.GetComponent<ChangeData>().GivePlayableEnemy();

        particulRecever = who.GetComponent<ChangeData>().GiveParticleRecever();

        Vector3 whereToSpawn = who.transform.position;

        particulRecever.SetActive(true);
        myParticleSystem.gameObject.SetActive(true);

        yield return new WaitForSeconds(myParticleSystem.main.duration);

        Destroy(who);
        yield return new WaitForEndOfFrame();
        Instantiate(toSpawn, whereToSpawn,Quaternion.identity);

        Destroy(gameObject);
    }
}
