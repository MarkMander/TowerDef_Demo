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

    public UnitManager unitManager;


    private void Awake()
    {
        if ((this.transform.position.x % 2 == 0 && this.transform.position.y % 2 == 0) || (this.transform.position.x % 2 == 1 && this.transform.position.y % 2 == 1))
        {
            tileRenderer.color = primaryColor;
        } else
        {
            //tileRenderer.color = secondaryColor;
            tileRenderer.color = primaryColor; //testing to make everything one color instead of checkerboard
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
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                unitManager.SpwnUnit(new Vector2(this.transform.position.x, this.transform.position.y));
                tileFull = true;
            } else if (eventData.button == PointerEventData.InputButton.Right)
            {
                Debug.Log("No Unit To Delete");
            }
        }
        else if (tileFull == true)
        {
            if (eventData.button == PointerEventData.InputButton.Right)
            {
                unitManager.DestroyUnit(new Vector2(this.transform.position.x, this.transform.position.y));
                tileFull = false;
            }
            else if (eventData.button == PointerEventData.InputButton.Left)
            {
                Debug.Log("Cannot Add Another Unit");
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        saveColor = tileRenderer.color;
        highlight = tileRenderer.color;
        highlight.a = 0.5f;
        tileRenderer.color = highlight;
        //Debug.Log(this.name);

        if (tileFull == true)
        {
            Unit attachedUnit = unitManager.GetUnit(new Vector2(this.transform.position.x, this.transform.position.y));
            attachedUnit.ToggleRange(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tileRenderer.color = saveColor;

        if (tileFull == true)
        {
            Unit attachedUnit = unitManager.GetUnit(new Vector2(this.transform.position.x, this.transform.position.y));
            attachedUnit.ToggleRange(false);
        }
    }

}
