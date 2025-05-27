using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public Tile tile;
    public int height, width;
    public Transform cameraTransform;


    void Start()
    {
        GenerateGrid();
        Debug.Log("Grid Generated");
        cameraTransform.position = new Vector3((float)width/2 - 0.5f, (float)height/2 - 0.5f,-10);
    }

    void GenerateGrid()
    {
        for (int i = 0; i < width; i++) 
        {
            for (int j = 0; j < height; j++)
            {
                var spwnTile = Instantiate(tile,new Vector3(i,j), Quaternion.identity);
                spwnTile.name = $"Tile {i}x{j}";
            }
        }
    }
}
