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


    private void Start()
    {
        placeModeOn = true;
        tileRenderer.color = primaryColor;
        highlight = tileRenderer.color;
        highlight.a = 0.5f;
    }

    void OnPlaceModeToggle()
    {
        placeModeOn = !placeModeOn;
        Debug.Log($"place mode is {placeModeOn}");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (placeModeOn)
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
        if (placeModeOn)
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
            tileRenderer.color = primaryColor;

            if (tileFull == true)
            {
                Unit attachedUnit = UnitManager.Instance.GetUnit(new Vector2(this.transform.position.x, this.transform.position.y));
                attachedUnit.ToggleRange(false);
            }
    }

}
