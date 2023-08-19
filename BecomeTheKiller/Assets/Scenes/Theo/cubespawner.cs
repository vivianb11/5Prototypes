using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class cubespawner : MonoBehaviour
{
    public GameObject cubeToSpawn;
    public List<GameObject> spawned;
    public List<GameObject> frams;
    public int hight, width;
    public Vector2 hole;
    public float offset;
    public float scaleSmall;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            FrameGenerator();
            frams.Add(new GameObject());

            foreach (var item in spawned)
            {
                item.transform.parent = frams[frams.Count-1].transform;
            }
            frams[frams.Count - 1].transform.localScale = new(2,2,1);
            frams[frams.Count-1].transform.DOScale(1, 0.5f);
            spawned.Clear();

            if (frams.Count > 2)
            {
                frams[1].transform.DOScale(scaleSmall,0.5f);
                frams[0].transform.DOScale(0.001f, 0.5f).OnComplete(()=> { Destroy(frams[0]); frams.Remove(frams[0]); });
            }
        }
    }


    public void FrameGenerator()
    {
        hole = RandomLogic(hight, width);

        for (int i = 0; i < hight; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (i == hole.x && j == hole.y ||
                    hole.x == 0 && j == hole.y + 1 && i == hole.x ||
                    hole.x == hight - 1 && j == hole.y + 1 && i == hole.x ||
                    hole.y == 0 && i == hole.x + 1 && j == hole.y ||
                    hole.y == width - 1 && i == hole.x + 1 && j == hole.y)
                {
                    continue;
                }
                if (i == 0 || j == 0 || i == hight - 1 || j == width - 1)
                {
                    spawned.Add(Instantiate(cubeToSpawn));
                    cubeToSpawn.transform.position = new Vector3(j + offset, i + offset, 0);
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
