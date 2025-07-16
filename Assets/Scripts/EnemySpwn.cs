using UnityEngine;

public class EnemySpwn : MonoBehaviour
{
    public EnemyUnit enemy;
    public float spwnRate = 10;
    private float timer = 0;

    // Update is called once per frame
    void Update()
    {
        if (timer > spwnRate)
        {
            spwnEnemyUnit();
            timer = 0;
        } else
        {
            timer = timer + Time.deltaTime;
        }
    }

    private void spwnEnemyUnit()
    {
        Instantiate(enemy, new Vector3(transform.position.x,transform.position.y),Quaternion.identity);
    }
}
