using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGenerationV2 : MonoBehaviour
{
    public Camera mainCamera;
    public Tilemap tilemap;
    public TileBase[] tiles;

    public int cellSize = 32;

    private Vector3Int lastCameraCellPos;

    private void Start()
    {
        lastCameraCellPos = GetCameraCellPos();
        GenerateTiles();
    }

    private void Update()
    {
        Vector3Int currentCameraCellPos = GetCameraCellPos();
        if (currentCameraCellPos != lastCameraCellPos)
        {
            lastCameraCellPos = currentCameraCellPos;
            GenerateTiles();
        }
    }

    private Vector3Int GetCameraCellPos()
    {
        Vector2 cameraPos = mainCamera.transform.position;
        //Vector2 camSize = new(mainCamera.scaledPixelWidth / 2, mainCamera.scaledPixelHeight / 2);
        int cellX = Mathf.FloorToInt(cameraPos.x / cellSize);
        int cellY = Mathf.FloorToInt(cameraPos.y / cellSize);
        return new Vector3Int(cellX, cellY, 0);
    }

    private void GenerateTiles()
    {
        int cellsInViewX = Mathf.CeilToInt(mainCamera.orthographicSize * 2 * mainCamera.aspect / cellSize) + 4;
        int cellsInViewY = Mathf.CeilToInt(mainCamera.orthographicSize * 2 / cellSize) + 4;


        int startX = lastCameraCellPos.x - cellsInViewX / 2;
        int startY = lastCameraCellPos.y - cellsInViewY / 2;

        for (int x = startX; x < startX + cellsInViewX; x++)
        {
            for (int y = startY; y < startY + cellsInViewY; y++)
            {
                Vector3Int cellPos = new(x, y, 0);
                if (tilemap.GetTile(cellPos) == null)
                {
                    TileBase tile = tiles[UnityEngine.Random.Range(0, tiles.Length)];
                    tilemap.SetTile(cellPos, tile);
                }
            }
        }
    }
}