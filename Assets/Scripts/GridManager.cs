using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public Tile tile;
    public int height, width;
    public Transform cameraTransform;

    

    public Dictionary<Vector2, Tile> GenerateGrid()
    {
        Dictionary<Vector2, Tile> tileDict = new Dictionary<Vector2, Tile>();
        for (int i = 0; i < width; i++) 
        {
            for (int j = 0; j < height; j++)
            {
                var spwnTile = Instantiate(tile,new Vector3(i,j), Quaternion.identity);
                spwnTile.name = $"Tile {i}x{j}";
                tileDict.Add(new Vector2(i,j), spwnTile);
            }
        }
        Debug.Log("Grid Generated");
        cameraTransform.position = new Vector3((float)width / 2 - 0.5f, (float)height / 2 - 0.5f, -10);
        return tileDict;
    }
}
