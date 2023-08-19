using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnIfNoEnemies : MonoBehaviour
{
    public Camera mainCamera;
    public float offset = 1f;
    private Vector2 detectionZoneCorner;
    private Vector2 spawnZoneCorner;
    public int minEnemiesInZone = 2;

    public List<GameObject> enemiesToSpawn;

    [SerializeField] private List<GameObject> enemiesAround;
    [SerializeField] private Collider2D[] detectedColliders;

    private void Start()
    {
        enemiesAround = new List<GameObject>();
    }

    private void Update()
    {
        if (mainCamera == null)
        {
            Debug.LogWarning("Main camera reference is missing. Please assign a camera in the Inspector.");
            return;
        }

        float detectionWidth = (mainCamera.orthographicSize * 2f * mainCamera.aspect) + Mathf.Max(offset, 0f);
        float detectionHeight = (mainCamera.orthographicSize * 2f) + Mathf.Max(offset, 0f);

        Vector2 cameraCenter = mainCamera.transform.position;

        Bounds detectionZoneBounds = new Bounds(cameraCenter, new Vector3(detectionWidth, detectionHeight, 0f));
        Bounds spawnZoneBounds = new Bounds(cameraCenter, new Vector3(detectionWidth - 0.1f, detectionHeight - 0.1f, 0f));

        detectedColliders = Physics2D.OverlapAreaAll(new Vector2(detectionZoneBounds.max.x, detectionZoneBounds.max.y), new Vector2(detectionZoneBounds.min.x, detectionZoneBounds.min.y),LayerMask.GetMask("Enemy"));

        foreach (Collider2D collider in detectedColliders)
        {
            GameObject enemy = collider.gameObject;
            if (!enemiesAround.Contains(enemy))
                enemiesAround.Add(enemy);
        }

        for (int i = enemiesAround.Count - 1; i >= 0; i--)
        {
            GameObject enemy = enemiesAround[i];
            if (enemy is null || !detectionZoneBounds.Contains(enemy.transform.position))
                enemiesAround.RemoveAt(i);
        }

        if (enemiesAround.Count < minEnemiesInZone && enemiesToSpawn.Count > 0)
        {
            Vector3 spawnPoint = GetRandomSpawnPoint(spawnZoneBounds);

            GameObject enemyToSpawn = enemiesToSpawn[Random.Range(0, enemiesToSpawn.Count)];
            Instantiate(enemyToSpawn, spawnPoint, Quaternion.identity);
        }
    }

    private Vector3 GetRandomSpawnPoint(Bounds spawnZoneBounds)
    {
        float x, y;
        if ((int)Random.Range(1, 3) == 1)
        {
            x = ((int)Random.Range(1, 3) == 1) ? spawnZoneBounds.min.x: spawnZoneBounds.max.x;
            y = Random.Range(spawnZoneBounds.min.y, spawnZoneBounds.max.y);
        }
        else
        {
            x = Random.Range(spawnZoneBounds.min.x, spawnZoneBounds.max.x);
            y = ((int)Random.Range(1, 3) == 1) ? spawnZoneBounds.min.y : spawnZoneBounds.max.y;
        }

        return new Vector3(x, y, 0);
    }

    private void OnDrawGizmos()
    {
        if (mainCamera == null)
            return;

        float detectionWidth = (mainCamera.orthographicSize * 2f * mainCamera.aspect) + Mathf.Max(offset, 0f);
        float detectionHeight = (mainCamera.orthographicSize * 2f) + Mathf.Max(offset, 0f);

        Gizmos.color = Color.green;
        Gizmos.matrix = Matrix4x4.TRS(transform.position, Quaternion.identity, new Vector3(detectionWidth, detectionHeight, 0f));
        Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
    }
}
