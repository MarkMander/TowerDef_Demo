using UnityEngine;

public class EnemyUnit : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float health = 200;
    public Rigidbody2D rBody;
    public float unitSpd = 3;
    public float deadzone = 20;
    // Update is called once per frame
    void Start()
    {
        rBody.linearVelocity = new Vector3(unitSpd,0);
    }

    void Update()
    {
        if (transform.position.x > deadzone)
        {
            Debug.Log("Enemy has reached base");
            Destroy(gameObject);
        }
    }

}
