using UnityEngine;
using UnityEngine.EventSystems;

public class Unit_Green : Unit
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private SpriteRenderer unitRenderer;
    public float adjustDmg = 100;
    public float adjustRange = 10;
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
        get { return Color.green; }
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
        Init();
        unitRenderer = GetComponent<SpriteRenderer>();
        unitRenderer.color = unitColor;
        ScaleVisableRange();
    }

    void FixedUpdate()
    {
        Tracking();
    }

}
