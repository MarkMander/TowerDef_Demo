using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Color primaryColor;
    private Color highlight;
    public SpriteRenderer tileRenderer;
    private bool tileFull = false;
    private bool placeModeOn;
    private bool validTile = false;
    private Collider2D tileCollider;


    private void Start()
    {
        placeModeOn = true;
        tileRenderer.color = primaryColor;
        highlight = tileRenderer.color;
        highlight.a = 0.5f;

        tileCollider = GetComponent<Collider2D>();
        List<Collider2D> colliders = new List<Collider2D>();
        int num = tileCollider.Overlap(colliders);
        if (num > 0)
        {
            for (int i = 0; i < num; i++)
            {
                if (colliders[i].gameObject.layer == 10) 
                {
                    validTile = true;
                }
            }
        }
        
    }

    void OnPlaceModeToggle()
    {
        placeModeOn = !placeModeOn;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (placeModeOn && validTile)
        {
            if (tileFull == false)
            {
                if (eventData.button == PointerEventData.InputButton.Left)
                {
                    UnitManager.Instance.SpwnUnit(new Vector2(this.transform.position.x, this.transform.position.y));
                    tileFull = true;
                }
                else if (eventData.button == PointerEventData.InputButton.Right)
                {
                    Debug.Log("No Unit To Delete");
                }
            }
            else if (tileFull == true)
            {
                if (eventData.button == PointerEventData.InputButton.Right)
                {
                    UnitManager.Instance.DestroyUnit(new Vector2(this.transform.position.x, this.transform.position.y));
                    tileFull = false;
                }
                else if (eventData.button == PointerEventData.InputButton.Left)
                {
                    Debug.Log("Cannot Add Another Unit");
                }
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (placeModeOn && validTile)
        {
            tileRenderer.color = highlight;

            if (tileFull == true)
            {
                Unit attachedUnit = UnitManager.Instance.GetUnit(new Vector2(this.transform.position.x, this.transform.position.y));
                attachedUnit.ToggleRange(true);
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (validTile)
        {
            tileRenderer.color = primaryColor;

            if (tileFull == true)
            {
                Unit attachedUnit = UnitManager.Instance.GetUnit(new Vector2(this.transform.position.x, this.transform.position.y));
                attachedUnit.ToggleRange(false);
            }
        }        
    }

    /*private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log("tile trigger triggered");
        Debug.Log($"layer {collision.gameObject.layer}");
        if (collision.gameObject.layer == 10)
        {
            validTile = false;
        }
    }*/

}
