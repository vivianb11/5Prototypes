using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorisontalEnemySpawner : MonoBehaviour
{
    int sRorL;

    public Camera cam;

    public GameObject ennemyToSpawn;

    private float camWidth, camHight;

    private void Start()
    {
        InvokeRepeating("Spawn",2,1);
        cam = Camera.main;
    }

    void Update()
    {
        camHight = cam.orthographicSize;
        camWidth = camHight * cam.aspect;
    }

    void Spawn()
    {
        sRorL = Random.Range(0, 2);
        if (sRorL == 0)
        {
            float spawnHight = Random.Range(-(camHight - 1), camHight - 1);
            float spawnSide = camWidth + 1;

            Instantiate(ennemyToSpawn,new Vector3(spawnSide,spawnHight,0),Quaternion.Euler(new Vector3(0,0,90)));
        }
        else
        {
            float spawnHight = Random.Range(-(camHight - 1), camHight - 1);
            float spawnSide = - (camWidth + 1);

            Instantiate(ennemyToSpawn, new Vector3(spawnSide, spawnHight, 0), Quaternion.Euler(new Vector3(0, 0, 90)));
        }
    }
}
