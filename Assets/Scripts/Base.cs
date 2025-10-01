using UnityEngine;

public class Base : MonoBehaviour
{
    public float health = 1000;
    public void TakeDmg(float dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
