using UnityEngine;

/**
 * Enemy.cs
 */
public class Enemy : MonoBehaviour
{
    public SpriteRenderer sprite;   // To flip the sprite depending on the direction

    public int health = 10;
    public int shield = 0;  // For headphone users
    public float speed = 10f;   // Control how fast this enemy type is

    int hp = 1;
    //int shp = 0; // For shields! (implement later!)

    private Path path;
    private Transform target;
    private int pointIndex = 0;

    private void Start()
    {
        target = path.points[0];
        hp = health;
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position; // Direction of movement
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);  // Move enemy


        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }

    public void TakeDamage(int d)
    {
        hp -= d;    // Take d amount of damage

        if (hp <= 0)
        {
            // Do death FX
            Destroy(gameObject);
        }
    }

    public void GetNextWaypoint()
    {
        if (pointIndex >= path.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        pointIndex++;
        target = path.points[pointIndex];
    }

    // Called when spawned
    public void SetPath(Path p)
    {
        path = p;
        pointIndex = 0;
    }
}
