using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGeneration : MonoBehaviour
{
    public Camera mainCamera;
    public Tilemap tilemap;
    public TileBase[] tiles;

    public int cellSize = 32;

    private Vector3Int lastCameraCellPos;

    private TileBase[] tilesInCameraField;

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
            GenerateTilesOutsideView();
        }
    }

    private Vector3Int GetCameraCellPos()
    {
        Vector2 cameraPos = mainCamera.transform.position;
        Vector2 camSize = new(mainCamera.scaledPixelWidth / 2, mainCamera.scaledPixelHeight / 2);
        int cellX = Mathf.FloorToInt(cameraPos.x / cellSize);
        int cellY = Mathf.FloorToInt(cameraPos.y / cellSize);
        BoundsInt cameraBounds = new BoundsInt(Mathf.FloorToInt(cameraPos.x - camSize.x), Mathf.FloorToInt(cameraPos.y - camSize.y), 0, Mathf.CeilToInt(camSize.x * 2), Mathf.CeilToInt(camSize.y * 2), 1);
        tilesInCameraField = tilemap.GetTilesBlock(cameraBounds);
        return new Vector3Int(cellX, cellY, 0);
    }

    private void GenerateTiles()
    {
        int cellsInViewX = Mathf.CeilToInt(mainCamera.orthographicSize * 2 * mainCamera.aspect / cellSize);
        int cellsInViewY = Mathf.CeilToInt(mainCamera.orthographicSize * 2 / cellSize);

        int startX = lastCameraCellPos.x - cellsInViewX / 2;
        int startY = lastCameraCellPos.y - cellsInViewY / 2;

        for (int x = startX; x < startX + cellsInViewX; x++)
        {
            for (int y = startY; y < startY + cellsInViewY; y++)
            {
                Vector3Int cellPos = new Vector3Int(x, y, 0);
                TileBase tile = tiles[UnityEngine.Random.Range(0, tiles.Length)];
                tilemap.SetTile(cellPos, tile);

            }
        }
    }

    private void GenerateTilesOutsideView()
    {
        int cellsInViewX = Mathf.CeilToInt(mainCamera.orthographicSize * 2 * mainCamera.aspect / cellSize);
        int cellsInViewY = Mathf.CeilToInt(mainCamera.orthographicSize * 2 / cellSize);

        int startX = lastCameraCellPos.x - cellsInViewX / 2;
        int endX = startX + cellsInViewX;
        int startY = lastCameraCellPos.y - cellsInViewY / 2;
        int endY = startY + cellsInViewY;

        // Parcours de toutes les cellules en dehors du champ de vue de la caméra
        for (int x = startX - 1; x >= 0; x--)
        {
            for (int y = startY - 1; y >= 0; y--)
            {
                Vector3Int cellPos = new Vector3Int(x, y, 0);
                if (!tilemap.HasTile(cellPos))
                {
                    TileBase tile = tiles[UnityEngine.Random.Range(0, tiles.Length)];
                    tilemap.SetTile(cellPos, tile);
                }
            }
            for (int y = endY; y <= endY + 1; y++)
            {
                Vector3Int cellPos = new Vector3Int(x, y, 0);
                if (!tilemap.HasTile(cellPos))
                {
                    TileBase tile = tiles[UnityEngine.Random.Range(0, tiles.Length)];
                    tilemap.SetTile(cellPos, tile);
                }
            }
        }
        for (int x = endX; x <= endX + 1; x++)
        {
            for (int y = startY - 1; y >= 0; y--)
            {
                Vector3Int cellPos = new Vector3Int(x, y, 0);
                if (!tilemap.HasTile(cellPos))
                {
                    TileBase tile = tiles[UnityEngine.Random.Range(0, tiles.Length)];
                    tilemap.SetTile(cellPos, tile);
                }
            }
            for (int y = endY; y <= endY + 1; y++)
            {
                Vector3Int cellPos = new Vector3Int(x, y, 0);
                if (!tilemap.HasTile(cellPos))
                {
                    TileBase tile = tiles[UnityEngine.Random.Range(0, tiles.Length)];
                    tilemap.SetTile(cellPos, tile);
                }
            }
        }
    }
}