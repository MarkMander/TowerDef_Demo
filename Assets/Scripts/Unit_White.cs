using UnityEngine;

public class Unit_White : Unit
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private SpriteRenderer unitRenderer;
    public float adjustDmg = 50;

    void Awake()
    {
        unitRenderer = GetComponent<SpriteRenderer>();
        base.Init(Color.white, unitRenderer, adjustDmg);
    }
}
