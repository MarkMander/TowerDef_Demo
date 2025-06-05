using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Color primaryColor;
    public Color secondaryColor;
    private Color highlight;
    public SpriteRenderer tileRenderer;
    private Color saveColor;
    private bool tileFull = false;
    //public bool requestSpwn = false;
    //public bool requestDestroy = false;

    public UnitManager unitManager;


    private void Awake()
    {
        if ((this.transform.position.x % 2 == 0 && this.transform.position.y % 2 == 0) || (this.transform.position.x % 2 == 1 && this.transform.position.y % 2 == 1))
        {
            tileRenderer.color = primaryColor;
        } else
        {
            tileRenderer.color = secondaryColor;
        }
    }

    private void Start()
    {
        unitManager = GameObject.FindGameObjectWithTag("UnitManager").GetComponent<UnitManager>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (tileFull == false)
        {
            //requestSpwn = true;
            unitManager.SpwnUnit(new Vector2(this.transform.position.x, this.transform.position.y));
            tileFull = true;
        }
        else
        {
            //requestDestroy = true;
            unitManager.DestroyUnit(new Vector2(this.transform.position.x, this.transform.position.y));
            tileFull = false;

        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        saveColor = tileRenderer.color;
        highlight = tileRenderer.color;
        highlight.a = 0.5f;
        tileRenderer.color = highlight;
        Debug.Log(this.name);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tileRenderer.color = saveColor;
    }

}
