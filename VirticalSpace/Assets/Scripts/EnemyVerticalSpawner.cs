using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVerticalSpawner : MonoBehaviour
{
    public DistanceFromCameraBounds distanceFromCameraBounds;

    public GameObject enemy;

    [SerializeField] Transform spawnTop;
    [SerializeField] Transform spawnBot;

    public float offset =1;

    Vector3 newPosition;

    bool coroutinActiv = false;
    public float timeBetweenSpawns;

    private void Start()
    {
        newPosition = spawnTop.localPosition;
        newPosition.y = distanceFromCameraBounds.distance + offset;
        spawnTop.localPosition = newPosition;

        spawnBot.localPosition = -newPosition;
    }

    void Update()
    {
        newPosition = spawnTop.localPosition;
        newPosition.y = distanceFromCameraBounds.distance + offset;
        spawnTop.localPosition = newPosition;

        spawnBot.localPosition = - newPosition;

        if (!coroutinActiv)
        {
            coroutinActiv = true;
            StartCoroutine(SpawnAlternativly());
        }
    }

    IEnumerator SpawnAlternativly()
    {
        yield return new WaitForSeconds(timeBetweenSpawns);
        Instantiate(enemy, spawnTop.position,spawnTop.rotation);

        yield return new WaitForSeconds(timeBetweenSpawns);
        Instantiate(enemy, spawnBot.position,spawnBot.rotation);
        coroutinActiv = false;
    }
}
