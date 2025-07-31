using UnityEngine;

public class Unit_Red : Unit
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private SpriteRenderer unitRenderer;
    public float adjustDmg = 100;
    public float adjustRange = 20;
    public float adjustRefresh = 1;
    public SpriteRenderer rangeRendererInstance;
    public Transform rangeTransformInstance;
    public LineRenderer lineRenderer;

    protected override float dmg
    {
        get { return adjustDmg; }
    }

    protected override float range
    {
        get { return adjustRange; }
    }

    protected override float fireRefresh
    {
        get { return adjustRefresh; }
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
    protected override LineRenderer turretRay
    {
        get { return lineRenderer; }
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
        timer = timer + Time.deltaTime;
        Tracking();
    }
}
