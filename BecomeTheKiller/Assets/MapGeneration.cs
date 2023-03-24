using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGeneration : MonoBehaviour
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
        Vector3 cameraPos = mainCamera.transform.position;
        int cellX = Mathf.FloorToInt(cameraPos.x / cellSize);
        int cellY = Mathf.FloorToInt(cameraPos.y / cellSize);
        return new Vector3Int(cellX, cellY, 0);
    }

    private void GenerateTiles()
    {
        int cellsInViewX = Mathf.CeilToInt(mainCamera.orthographicSize * 2 * mainCamera.aspect / cellSize);
        int cellsInViewY = Mathf.CeilToInt(mainCamera.orthographicSize * 2 / cellSize);

        int startX = lastCameraCellPos.x - cellsInViewX / 2;
        int startY = lastCameraCellPos.y - cellsInViewY / 2;

        tilemap.ClearAllTiles();

        for (int x = startX; x < startX + cellsInViewX; x++)
        {
            for (int y = startY; y < startY + cellsInViewY; y++)
            {
                Vector3Int cellPos = new Vector3Int(x, y, 0);
                TileBase tile = tiles[Random.Range(0, tiles.Length)];
                tilemap.SetTile(cellPos, tile);
            }
        }
    }
}

    //private void GenerateTiles()
    //{
    //    int cellsInViewX = Mathf.CeilToInt(mainCamera.orthographicSize * 2 / cellSize);
    //    int cellsInViewY = Mathf.CeilToInt(mainCamera.orthographicSize * 2 / cellSize);

//    int startX = lastCameraCellPos.x - cellsInViewX / 2;
//    int startY = lastCameraCellPos.y - cellsInViewY / 2;

//    tilemap.ClearAllTiles();

//    if (tiles.Length == 0)
//    {
//        Debug.LogWarning("No tiles assigned to the tiles array.");
//        return;
//    }

//    for (int x = startX; x < startX + cellsInViewX; x++)
//    {
//        for (int y = startY; y < startY + cellsInViewY; y++)
//        {
//            Vector3Int cellPos = new Vector3Int(x, y, 0);

//            if (tiles.Length > 0)
//            {
//                TileBase tile = tiles[Random.Range(0, tiles.Length)];
//                tilemap.SetTile(cellPos, tile);
//            }
//            else
//            {
//                Debug.LogWarning("No tiles assigned to the tiles array.");
//            }
//        }
//    }
//}
//public class MapGeneration : MonoBehaviour
//{
//    public Camera mainCamera;
//    public Tilemap tilemap;
//    public TileBase[] tiles;

//    public int cellWidth = 32;
//    public int cellHeight = 32;

//    private Dictionary<Vector2Int, TileBase> cellMap = new Dictionary<Vector2Int, TileBase>();

//    private Vector2Int lastCameraCellPos;

//    private void Start()
//    {
//        lastCameraCellPos = GetCameraCellPos();
//        GenerateTiles();
//    }

//    private void Update()
//    {
//        Vector2Int currentCameraCellPos = GetCameraCellPos();
//        if (currentCameraCellPos != lastCameraCellPos)
//        {
//            lastCameraCellPos = currentCameraCellPos;
//            GenerateTiles();
//        }
//    }

//    private Vector2Int GetCameraCellPos()
//    {
//        Vector3 cameraPos = mainCamera.transform.position;
//        int cellX = Mathf.RoundToInt(cameraPos.x / cellWidth);
//        int cellY = Mathf.RoundToInt(cameraPos.y / cellHeight);
//        return new Vector2Int(cellX, cellY);
//    }

//    private void GenerateTiles()
//    {
//        int cellsInViewX = Mathf.CeilToInt(mainCamera.orthographicSize * 2 / cellHeight);
//        int cellsInViewY = Mathf.CeilToInt(mainCamera.orthographicSize * 2 / cellWidth);

//        int startX = lastCameraCellPos.x - cellsInViewX / 2;
//        int startY = lastCameraCellPos.y - cellsInViewY / 2;

//        for (int x = startX - 1; x <= startX + cellsInViewX; x++)
//        {
//            for (int y = startY - 1; y <= startY + cellsInViewY; y++)
//            {
//                Vector2Int cellPos = new Vector2Int(x, y);

//                if (cellMap.ContainsKey(cellPos))
//                {
//                    // If the cell has already been generated, skip it
//                    continue;
//                }

//                TileBase tile = tiles[Random.Range(0, tiles.Length)];
//                tilemap.SetTile(new Vector3Int(cellPos.x * cellWidth, cellPos.y * cellHeight, 0), tile);

//                // Add the cell to the dictionary
//                cellMap.Add(cellPos, tile);
//            }
//        }
//    }
//}



//    //private void GenerateTiles()
//    //{
//    //    int cellsInViewX = Mathf.CeilToInt(mainCamera.orthographicSize * 2 / cellSize);
//    //    int cellsInViewY = Mathf.CeilToInt(mainCamera.orthographicSize * 2 / cellSize);

//    //    int startX = lastCameraCellPos.x - cellsInViewX / 2;
//    //    int startY = lastCameraCellPos.y - cellsInViewY / 2;

//    //    tilemap.ClearAllTiles();

//    //    for (int x = startX; x < startX + cellsInViewX; x++)
//    //    {
//    //        for (int y = startY; y < startY + cellsInViewY; y++)
//    //        {
//    //            Vector3Int cellPos = new Vector3Int(x, y, 0);
//    //            TileBase tile = tiles[Random.Range(0, tiles.Length)];
//    //            if (tile != null)
//    //            {
//    //                tilemap.SetTile(cellPos, tile);
//    //            }
//    //        }
//    //    }
//    //}

//    //private void GenerateTiles()
//    //{
//    //    int cellsInViewX = Mathf.CeilToInt(mainCamera.orthographicSize * 2 / cellSize);
//    //    int cellsInViewY = Mathf.CeilToInt(mainCamera.orthographicSize * 2 / cellSize);

//    //    int startX = lastCameraCellPos.x - cellsInViewX / 2;
//    //    int startY = lastCameraCellPos.y - cellsInViewY / 2;

//    //    tilemap.ClearAllTiles();

//    //    for (int x = startX; x < startX + cellsInViewX; x++)
//    //    {
//    //        for (int y = startY; y < startY + cellsInViewY; y++)
//    //        {
//    //            Vector3Int cellPos = new Vector3Int(x, y, 0);
//    //            TileBase tile = tiles[Random.Range(0, tiles.Length)];
//    //            tilemap.SetTile(cellPos, tile);
//    //        }
//    //    }
//    //}
//}
