using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;

public abstract class Unit : MonoBehaviour
{
    protected LayerMask enemyMask;
    protected float timer = 0;
    protected abstract Color unitColor { get; }
    protected abstract float dmg { get; } 
    protected abstract float range { get; }
    protected abstract float fireRefresh { get; }
    protected abstract SpriteRenderer rangeRenderer {  get; }
    protected abstract Transform rangeTransform { get; }
    protected abstract LineRenderer turretRay { get; }

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
        if (hits.Length > 0 && timer > fireRefresh)
        {
            StartCoroutine(FireTurret(hits[0]));
            timer = 0;
        }
    }

    IEnumerator FireTurret(RaycastHit2D hit)
    {
        Vector3[] positions = new Vector3[2];
        //positions[0] = new Vector3(this.transform.position.x,this.transform.position.y,0);
        //positions[1] = new Vector3(hit.point.x,hit.point.y,0);
        positions[0] = this.transform.position;
        positions[1] = hit.transform.localPosition;

        turretRay.positionCount = positions.Length;
        turretRay.positionCount = positions.Length;
        turretRay.SetPositions(positions);
        turretRay.enabled = true;
        EnemyUnit hitUnit = hit.transform.GetComponent<EnemyUnit>();
        hitUnit.TakeDmg(this.dmg);

        yield return new WaitForSeconds(0.04f);

        turretRay.enabled = false;
    }


}
