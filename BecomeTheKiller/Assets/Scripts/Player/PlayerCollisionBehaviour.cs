using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionBehaviour : MonoBehaviour
{
    public PlayerSpawnIfNoEnemies playerSpawnIfNoEnemies;

    public ParticleSystem myParticleSystem;

    private Rigidbody2D rb;

    private GameObject particulRecever;

    public float particlReceverRadiusDetection;

    bool particulesArived = false;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            rb.velocity = Vector2.zero;
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            playerSpawnIfNoEnemies.enabled = false;

            collision.gameObject.GetComponent<Behaviour>().enabled = false;
            this.GetComponent<GlobalControler>().enabled = false;

            StartCoroutine(DetructionProtocol(collision.gameObject));
        }
    }

    IEnumerator DetructionProtocol(GameObject who)
    {
        GetData gD;
        gD = who.GetComponent<GetData>();

        GameObject toSpawn = gD.dataToGive[0].GetGoData();

        particulRecever = gD.dataToGive[1].GetGoData();

        Vector3 whereToSpawn = who.transform.position;

        particulRecever.SetActive(true);
        myParticleSystem.gameObject.SetActive(true);

        while (ParticulesArrived())
        {
            yield return new WaitForSeconds(0.1f);
        }

        Destroy(who);
        yield return new WaitForEndOfFrame();
        Instantiate(toSpawn, whereToSpawn,Quaternion.identity);

        Destroy(gameObject);
    }

    private bool ParticulesArrived()
    {
        ParticleSystem.Particle[] particles = new ParticleSystem.Particle[myParticleSystem.main.maxParticles];
        int particleCount = myParticleSystem.GetParticles(particles);

        for (int i = 0; i < particleCount; i++)
        {
            Vector2 position = particles[i].position;
            float distance = Vector2.Distance(position,particulRecever.transform.position);

            if (distance > particlReceverRadiusDetection)
            {
                return false;
            }
        }
        return true;
    }


    private void OnDrawGizmos()
    {
        if (particulRecever == null)
            return;

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(particulRecever.transform.position,particlReceverRadiusDetection);
    }
}
