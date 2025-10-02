using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridManager : MonoBehaviour
{
    public Tile tile;
    public int height, width;

    public Dictionary<Vector2, Tile> GenerateGrid()
    {
        Dictionary<Vector2, Tile> tileDict = new Dictionary<Vector2, Tile>();
        for (int i = -width/2; i < width/2; i++) 
        {
            for (int j = -height/2; j < height/2; j++)
            {
                var spwnTile = Instantiate(tile,new Vector3((float)(i+0.5),(float)(j+0.5)), Quaternion.identity);
                spwnTile.name = $"Tile {i}x{j}";
                tileDict.Add(new Vector2(i,j), spwnTile);
            }
        }
        Debug.Log("Grid Generated");
        return tileDict;
    }
}
