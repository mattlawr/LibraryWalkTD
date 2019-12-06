using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 10;
    public float speed = 10f;

    private Transform target;
    private int wavepointIndex;
    private int tempIndex;

    private void Start()
    {
        wavepointIndex = tempIndex;
        target = Waypoints.points[0];
    }

    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }

        target = Waypoints.points[wavepointIndex];


        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);


        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }

    public void SetWaypoint(int index)
    {
        tempIndex = index;
        wavepointIndex = index;
        target = Waypoints.points[index];
        print(wavepointIndex + " TEST");
    }

    public void GetNextWaypoint()
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
