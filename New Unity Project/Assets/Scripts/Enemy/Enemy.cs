/**
 * Enemy.cs
 * Handles all enemy logic:
 *      - follows a Path from one edge of the screen to the other
 *      - takes damage and dies when health falls below zero
 *      - ?other features? i.e. slow down when hit?
 * 
 * Will be spawned by a SpawnManager class.
 * 
 * Author: Matthew Lawrence and Enemy/Tower Team
 */
using UnityEngine;

/// <summary>
/// Class for objects to decide where to move next, when to take damage, when to die, etc.
/// </summary>
public class Enemy : MonoBehaviour
{
    public SpriteRenderer sprite;   // To flip the sprite depending on the direction

    public int health = 10;
    //public int shield = 0;  // For headphone users (not implemented)
    public float speed = 10f;   // Control how fast this enemy type is

    int hp = 1; // so that "health" acts as a maximum health
    //int shp = 0; // For shields! (implement later!)

    private Path path;  // Holds all the points in this path
    private Transform target;   // The next point in this path to move towards
    private int pointIndex = 0;

    private void Start()
    {
        if (path)
        {
            target = path.points[0];
        }

        hp = health;

        if (!sprite)
        {
            Debug.LogError("[sprite]" + " variable unset!");
        }
    }

    private void Update()
    {
        if (!target) { return; }

        Vector3 dir = target.position - transform.position; // Direction of movement
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);  // Move enemy

        // Method to change sprite direction based on "dir"
        SpriteDirection(dir);

        // If the target point is reached:
        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();  // Get the next point.
        }
    }

    // Called by bullets when hit
    public void TakeDamage(int dmg)
    {
        hp -= dmg;    // Take dmg amount of damage

        if (hp <= 0)
        {
            // Do death FX
            Destroy(gameObject);
        }
    }

    // Called when target is reached
    void GetNextWaypoint()
    {
        if (pointIndex >= path.points.Length - 1)
        {
            Destroy(gameObject);
            // LAST WAYPOINT in array

            GameManager.instance.LoseHealth(1);

            return;
        }
        pointIndex++;
        target = path.points[pointIndex];
    }

    // Flips sprite if not facing dir
    void SpriteDirection(Vector2 dir)
    {
        if (!sprite) {
            return;
        }

        bool left = !sprite.flipX;  // If not flipped, assume facing left

        // Check directions (right, then left)
        if(dir.x > 0f && left)
        {
            sprite.flipX = true;
        }
        else if (dir.x < 0f && !left)
        {
            sprite.flipX = false;
        }
    }

    // Called when spawned by SpawnManager...
    /// <summary>
    /// Assign the destined path, and start following it from the beginning.
    /// </summary>
    /// <param name="p">The path for this enemy to keep track of</param>
    public void SetPath(Path p)
    {
        path = p;
        SetPath();  // Begins path
    }
    void SetPath()
    {
        pointIndex = 0; // Resets waypoint index
    }
}
