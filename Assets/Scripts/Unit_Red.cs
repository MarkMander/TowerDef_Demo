using UnityEngine;

public class Unit_Red : Unit
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private SpriteRenderer unitRenderer;
    public float adjustDmg = 200;
    public float adjustRange = 20;
    public SpriteRenderer rangeRendererInstance;
    public Transform rangeTransformInstance;

    protected override float dmg
    {
        get { return adjustDmg; }
    }

    protected override float range
    {
        get { return adjustRange; }
    }

    protected override Color unitColor
    {
        get { return Color.red; }
    }

    protected override SpriteRenderer rangeRenderer
    {
        get { return rangeRendererInstance; }
    }
    protected override Transform rangeTransform
    {
        get { return rangeTransformInstance; }
    }

    void Awake()
    {
        unitRenderer = GetComponent<SpriteRenderer>();
        unitRenderer.color = unitColor;
        ScaleVisableRange();
    }
}
