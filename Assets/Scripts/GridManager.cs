using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public Tile tile;
    public int height, width;
    //public Transform cameraTransform;
    //public float spwnX = -5;
    //public EnemySpwn enemySpwnPt;

    

    public Dictionary<Vector2, Tile> GenerateGrid()
    {
        Dictionary<Vector2, Tile> tileDict = new Dictionary<Vector2, Tile>();
        for (int i = -width/2; i < width/2; i++) 
        {
            for (int j = -height/2; j < height/2; j++)
            {
                var spwnTile = Instantiate(tile,new Vector3(i,j), Quaternion.identity);
                spwnTile.name = $"Tile {i}x{j}";
                tileDict.Add(new Vector2(i,j), spwnTile);
            }
        }
        Debug.Log("Grid Generated");

        //Instantiate(enemySpwnPt, new Vector3(spwnX,(float)height / 2 - 0.5f), Quaternion.identity);

        //cameraTransform.position = new Vector3((float)width / 2 - 0.5f, (float)height / 2 - 0.5f, -10);
        return tileDict;
    }
}
