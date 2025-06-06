using UnityEngine;

public class Unit_Green : Unit
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Color unitColor;
    private SpriteRenderer unitRenderer;

    void Start()
    {
        unitColor = Color.green;
        unitRenderer = GetComponent<SpriteRenderer>();
        unitRenderer.color = unitColor;

        base.generateName(unitColor);
    }


}
