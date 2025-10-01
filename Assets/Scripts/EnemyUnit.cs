using UnityEngine;

public class EnemyUnit : MonoBehaviour
{
    public float health = 200;
    public Rigidbody2D rBody;
    public float unitSpd = 3;
    private Transform targetPath;
    private int pathIdx = 0;

    void Start()
    {
        targetPath = UnitManager.Instance.path[pathIdx]; 
        //rBody.linearVelocity = new Vector3(unitSpd,0);
    }

    void Update()
    {
        if (Vector2.Distance(targetPath.position, this.transform.position) <= 0.1f)
        {
            pathIdx++;
            if (pathIdx > UnitManager.Instance.path.Length)
            {
                Destroy(gameObject);
                return;
            } else
            {
                targetPath = UnitManager.Instance.path[pathIdx];
            }
            
        }
        //if (false)//collides with base collider
        //{
        //Debug.Log("Enemy has reached base");
        //Destroy(gameObject);
        //}
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

}
