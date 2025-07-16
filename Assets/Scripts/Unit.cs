using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Unit : MonoBehaviour
{
    protected LayerMask enemyMask;
    protected abstract Color unitColor { get; }
    protected abstract float dmg { get; } 
    protected abstract float range { get; }
    protected abstract SpriteRenderer rangeRenderer {  get; }
    protected abstract Transform rangeTransform { get; }

    protected void Init()
    {
        enemyMask = LayerMask.GetMask("Enemy");
    }

    public void ToggleRange(bool enable)
    {
        this.rangeRenderer.enabled  = enable;
    }

    protected void ScaleVisableRange()
    {
        this.rangeTransform.localScale = new Vector3(this.range,this.range,1);
    }
    protected void Tracking()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(this.transform.position, this.range/2, (Vector2)this.transform.position, 0f, enemyMask);
        Debug.Log("");
        if (hits.Length > 0)
        {
            Debug.Log(hits);
        }
    }


}
