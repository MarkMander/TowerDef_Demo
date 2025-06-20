using UnityEngine;

public class EnemyUnit : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float health = 200;
    public Rigidbody2D rBody;
    private float unitSpd = 3;
    // Update is called once per frame
    void Start()
    {
        rBody.linearVelocity = new Vector3(unitSpd,0);
    }

}
