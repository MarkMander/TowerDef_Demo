using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Unit : MonoBehaviour
{
    protected abstract Color unitColor { get; }
    protected abstract float dmg { get; }
    protected abstract float range { get; }
    protected abstract SpriteRenderer rangeRenderer {  get; }
    protected abstract Transform rangeTransform { get; }


    /*protected void Init(Color color, SpriteRenderer unitRenderer, float unitDmg)
    {
        this.unitColor = color;
        unitRenderer.color = this.unitColor;

        this.dmg = unitDmg;

        this.name = $"Unit_{this.dmg}";
    }*/

    public void ToggleRange(bool enable)
    {
        this.rangeRenderer.enabled  = enable;
        Debug.Log("range toggled on");
    }

    protected void ScaleVisableRange()
    {
        this.rangeTransform.localScale = new Vector3(this.range,this.range,1);
        Debug.Log("visible range scaled");
    }
    protected void Tracking()
    {
         //track target
    }


}
