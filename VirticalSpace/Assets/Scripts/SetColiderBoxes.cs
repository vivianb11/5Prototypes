using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetColiderBoxes : MonoBehaviour
{
    public Camera mainCamera;

    float camSize;

    public List<BoxCollider2D> boxcolliders;

    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }

        camSize = mainCamera.orthographicSize;
        
        //GetComponents<BoxCollider2D>(boxcolliders);

        SetColiders();
    }

    void Update()
    {
        if (camSize != mainCamera.orthographicSize)
        {
            SetColiders();
            camSize = mainCamera.orthographicSize;
        }
    }

    void SetColiders()
    {
        for (int i = 0; i < boxcolliders.Count; i++)
        {
            if (i == 0)
            {
                boxcolliders[i].offset = new(0,camSize + 0.5f);
                boxcolliders[i].size = new(camSize * mainCamera.aspect * 2, 1);
            }
            if (i == 1)
            {
                boxcolliders[i].offset = new(0, -(camSize + 0.5f));
                boxcolliders[i].size = new(camSize * mainCamera.aspect * 2, 1);
            }
            if (i == 2)
            {
                boxcolliders[i].offset = new(camSize * mainCamera.aspect + 0.5f, 0);
                boxcolliders[i].size = new(1, camSize * 2);
            }
            if (i == 3)
            {
                boxcolliders[i].offset = new(-(camSize * mainCamera.aspect + 0.5f), 0);
                boxcolliders[i].size = new(1, camSize * 2);
            }
        } 
    }
}
