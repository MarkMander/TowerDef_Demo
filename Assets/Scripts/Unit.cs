using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    protected Color unitColor;

    protected void Init(Color color, SpriteRenderer unitRenderer)
    {
        unitColor = color;
        unitRenderer.color = unitColor;
        this.name = $"Unit_{unitColor}";
    }
    //protected void generateName(Color unitColor)
    //{
      //  this.name = $"Unit_{unitColor}";
    //}

    protected void tracking()
    {
        //track target
    }
}
