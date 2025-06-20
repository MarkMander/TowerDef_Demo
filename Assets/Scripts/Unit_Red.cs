using UnityEngine;

public class Unit_Red : Unit
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private SpriteRenderer unitRenderer;
    public float adjustDmg = 200;

    void Awake()
    {
        unitRenderer = GetComponent<SpriteRenderer>();
        base.Init(Color.red,unitRenderer,adjustDmg);
    }
}
