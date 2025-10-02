using UnityEngine;

public class EnemyUnit : MonoBehaviour
{
    public float health = 200;
    public Rigidbody2D rBody;
    public float unitSpd = 3;
    private Transform targetPath;
    private int pathIdx = 0;
    public float baseDmg = 100;

    void Start()
    {
        targetPath = UnitManager.Instance.path[pathIdx];
    }

    void Update()
    {
        if (Vector2.Distance(targetPath.position, this.transform.position) <= 0.1f)
        {
            pathIdx++;
            if (pathIdx >= UnitManager.Instance.path.Length)
            {
                Destroy(gameObject);
                return;
            } else
            {
                targetPath = UnitManager.Instance.path[pathIdx];
            }
            
        }
    }

    void FixedUpdate()
    {
        Vector2 direction = (targetPath.position-this.transform.position).normalized;
        rBody.linearVelocity = new Vector3(direction.x, direction.y) * unitSpd;
    }

    public void TakeDmg(float dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            Debug.Log($"{collision.gameObject.name} has been hit");
            UnitManager.Instance.DmgBase(baseDmg);
            Destroy(gameObject);
        }
    }

}
