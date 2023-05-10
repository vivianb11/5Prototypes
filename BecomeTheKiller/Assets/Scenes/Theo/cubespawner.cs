using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubespawner : MonoBehaviour
{
    public GameObject cubeToSpawn;

    public List<GameObject> spawned;

    public int hight, width;

    public Vector2 hole;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (spawned != null)
            {
                foreach (var cube in spawned)
                {
                    Destroy(cube);
                }
            }

            hole = RandomLogic(hight,width);

            for (int i = 0; i < hight; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (i == hole.x && j == hole.y || 
                        hole.x == 0 && j == hole.y + 1 && i == hole.x || 
                        hole.x == hight-1 && j == hole.y + 1 && i == hole.x ||
                        hole.y == 0 && i == hole.x + 1 && j == hole.y|| 
                        hole.y == width - 1 && i == hole.x + 1 && j == hole.y)
                    {
                        continue;
                    }
                    if (i == 0 || j == 0 || i == hight-1 || j == width - 1)
                    { 
                        spawned.Add(Instantiate(cubeToSpawn));
                        cubeToSpawn.transform.position = new Vector3(j, i, 0);  
                    }
                }
            }
        }

    }


    private Vector2 RandomLogic( int imax, int jmax )
    {
        int a, b;
        if ((int)Random.Range(1,3) == 1)
        {
            a = ((int)Random.Range(1,3) == 1) ? 0 : imax-1;
            b = UnityEngine.Random.Range(1, jmax - 2);
        }
        else
        {
            a = UnityEngine.Random.Range(1, imax - 2);
            b = ((int)Random.Range(1, 3) == 1) ? 0 : jmax-1;
        }
        
        Vector2 resault = new(a,b);
        return resault;
    }
}
