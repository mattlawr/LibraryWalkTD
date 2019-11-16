using UnityEngine;

public class Clique : MonoBehaviour
{
    public int health = 30;
    public float speed = 5f;

    private Transform target;
    private int wavepointIndex = 0;

    Enemy test;

    private void Start()
    {
        target = Waypoints.points[0];
    }

    private void Update()
    {
        if (health <= 0)
        {
            
            Enemy test2 = Instantiate(test, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }
}
