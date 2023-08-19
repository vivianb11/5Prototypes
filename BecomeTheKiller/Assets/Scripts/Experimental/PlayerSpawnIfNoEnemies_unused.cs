using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerSpawnIfNoEnemies_unused : MonoBehaviour
{

    public List<GameObject> enemiesToSpawn;

    [SerializeField] List<GameObject> enemiesAround;

    public float detectionRadius = 16;

    List<Collider2D> detectedObjects;

    private Camera cam;

    private void Start()
    {
        detectedObjects = new();
        cam = Camera.main;
    }

    void Update()
    {
        Physics2D.OverlapCapsule((Vector2)transform.position, new(detectionRadius + 2, detectionRadius/2), CapsuleDirection2D.Horizontal, 0 , new ContactFilter2D().NoFilter(), detectedObjects);

        //Physics2D.OverlapCircle((Vector2)transform.position, detectionRadius + 2, new ContactFilter2D().NoFilter(), detectedObjects);
        foreach (Collider2D collider in detectedObjects)
        {
            if (collider.gameObject.CompareTag("Enemy"))
            {
                // Add the enemy to the list if it isn't already there
                if (!enemiesAround.Contains(collider.gameObject))
                {
                    enemiesAround.Add(collider.gameObject);
                }
            }
        }
        for (int i = enemiesAround.Count - 1; i >= 0; i--)
        {
            if (enemiesAround[i] == null)
            {
                enemiesAround.RemoveAt(i);
                continue;
            }

            GameObject enemy = enemiesAround[i];
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance > detectionRadius + 2)
            {
                enemiesAround.RemoveAt(i);
            }
        }


        if (enemiesAround.Count <= 1 && enemiesToSpawn.Count > 0)
        {
            Vector3 spawnPoint = Random.insideUnitSphere * (detectionRadius + 2) ;
            spawnPoint += transform.position;

            float distanceToPlayer = Vector3.Distance(spawnPoint, transform.position);

            if (distanceToPlayer > detectionRadius)
            {
                Instantiate(enemiesToSpawn[(int)Random.Range(0, enemiesToSpawn.Count)], spawnPoint, Quaternion.identity);
            }
        }
    }

    private void OnDrawGizmos()
    {
        //Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere((Vector2)transform.position, detectionRadius);


        Gizmos.color = Color.green;

        // Calculate the capsule dimensions
        Vector2 center = transform.position;
        float height = detectionRadius / 2f;
        float width = detectionRadius + 2f;

        // Draw the capsule shape using Gizmos
        Vector2 topSphereCenter = center + Vector2.up * (height - width / 2f);
        Vector2 bottomSphereCenter = center + Vector2.down * (height - width / 2f);

        // Draw the top and bottom spheres
        Gizmos.DrawWireSphere(topSphereCenter, width / 2f);
        Gizmos.DrawWireSphere(bottomSphereCenter, width / 2f);

        // Draw the cylinder part
        float cylinderHeight = 2f * (height - width / 2f);
        Vector2 cylinderSize = new Vector2(width, cylinderHeight);
        Gizmos.DrawWireCube(center, cylinderSize);
    }
}


//Physics2D.OverlapArea((Vector2)this.transform.position + new Vector2(-cam.orthographicSize * cam.aspect, cam.orthographicSize), (Vector2)this.transform.position + new Vector2(cam.orthographicSize * cam.aspect, -cam.orthographicSize));
