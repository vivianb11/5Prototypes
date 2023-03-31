using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnIfNoEnnemies : MonoBehaviour
{

    public List<GameObject> enemiesToSpawn;

    [SerializeField] List<GameObject> enemiesAround;

    public float detectionRadius =20;

    List<Collider2D> detectedObjects;

    private void Start()
    {
        detectedObjects = new();
    }

    // Update is called once per frame
    void Update()
    {
         Physics2D.OverlapCircle((Vector2)transform.position, detectionRadius,new ContactFilter2D().NoFilter() , detectedObjects);
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
            if (distance > detectionRadius)
            {
                enemiesAround.RemoveAt(i);
            }
        }


        if (enemiesAround.Count <= 1)
        {
            Vector3 spawnPoint = Random.insideUnitSphere * detectionRadius;
            spawnPoint += transform.position;

            float distanceToPlayer = Vector3.Distance(spawnPoint, transform.position);
            if (distanceToPlayer > 3)
            {
                Instantiate(enemiesToSpawn[(int)Random.Range(0, enemiesToSpawn.Count)], spawnPoint, Quaternion.identity);
            }

        }
    }
}
