using UnityEngine;

public class Clique : MonoBehaviour
{
    public int health = 30;
    public float speed = 5f;

    public Transform target;
    public int wavepointIndex = 0;

    // Clique splits up into individuals when clique health is depleted
    public Enemy individual;

    private void Start()
    {
        target = Waypoints.points[0];
    }

    private void Update()
    {
        if (health <= 0)
        {
            Vector3 position = transform.position;
            Quaternion rotation = transform.rotation;

            // Need to add a delay so that transform can still be used
            Enemy normalEnemy = Instantiate(individual, position, rotation) as Enemy;
            normalEnemy.wavepointIndex = wavepointIndex;
            // Delay here
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
