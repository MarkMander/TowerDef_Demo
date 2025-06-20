using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    protected Color unitColor;
    public float dmg;

    protected void Init(Color color, SpriteRenderer unitRenderer, float unitDmg)
    {
        this.unitColor = color;
        unitRenderer.color = this.unitColor;

        this.dmg = unitDmg;

        this.name = $"Unit_{this.dmg}";
    }

    public float getDmg()
    {
        return dmg;
    }

    protected void tracking()
    {
        //track target
    }
}
