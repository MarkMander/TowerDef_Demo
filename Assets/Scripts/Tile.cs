using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Color primaryColor;
    public Color secondaryColor;
    public Color highlight;
    public SpriteRenderer tileRenderer;
    public Transform tileTransform;
    private Color saveColor;

    private void Awake()
    {
        if ((tileTransform.position.x % 2 == 0 && tileTransform.position.y % 2 == 0) || (tileTransform.position.x % 2 == 1 && tileTransform.position.y % 2 == 1))
        {
            tileRenderer.color = primaryColor;
        } else
        {
            tileRenderer.color = secondaryColor;
        }
    }

    private void OnMouseEnter()
    {
        
        saveColor = tileRenderer.color;
        tileRenderer.color = highlight;
        Debug.Log(this.name);
    }

    private void OnMouseExit()
    {
        tileRenderer.color = saveColor;
    }


    //add function to change the size of the tile on instantiation, for now stick with 1:1
}
