using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Tile : MonoBehaviour
{
    public Color primaryColor;
    public Color secondaryColor;
    private Color highlight;
    public SpriteRenderer tileRenderer;
    public Transform tileTransform;
    private Color saveColor;
    public InputAction placeAction;
    public InputAction deleteAction;
    private bool tileFull = false;
    public bool requestSpwn = false;
    public bool requestDestroy = false;


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

    private void Start()
    {
        placeAction = InputSystem.actions.FindAction("Place");
        deleteAction = InputSystem.actions.FindAction("Delete");
    }


    private void OnMouseEnter()
    {
        
        saveColor = tileRenderer.color;
        highlight = tileRenderer.color;
        highlight.a = 0.5f;
        tileRenderer.color = highlight;
        Debug.Log(this.name);
    }

    private void OnMouseExit()
    {
        tileRenderer.color = saveColor;
    }

    private void OnMouseDown()
    {
        if (tileFull == false)
        {
            requestSpwn = true;
            tileFull = true;
            Debug.Log("spwn requested");
        }
        else
        {
            requestDestroy = true;
            tileFull = false;
            Debug.Log("destroy requested");

        }
    }

    /*private void Update()
    {
        if (placeAction.IsPressed() && tileFull == false)
        {
            var placedObjectInstance = Instantiate(activeObject, new Vector3(transform.position.x, transform.position.y, -5), Quaternion.identity);
            placedObjectInstance.name = $"Obj";
            tileFull = true;
            placedObjectDict[new Vector2(transform.position.x,transform.position.y)] = placedObjectInstance;
            Debug.Log(placedObjectDict[new Vector2(transform.position.x, transform.position.y)].name);
            Debug.Log("object placed");
        }
        if (deleteAction.IsPressed() && tileFull == true)
        {
            //Destroy(placedObjectDict[new Vector2(transform.position.x,transform.position.y)]);
            Debug.Log(placedObjectDict[new Vector2(transform.position.x, transform.position.y)].name);
            tileFull = false;
            Debug.Log("object destroyed");
        }
    }*/


    //add function to change the size of the tile on instantiation, for now stick with 1:1
}
