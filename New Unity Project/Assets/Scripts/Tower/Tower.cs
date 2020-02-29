/**
 * Tower.cs
 * Derived from Tower Team project
 * Author: Matthew Lawrence and Tower Team (Do take credit y'all)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that targets Enemy objects within a trigger collider and fires Bullets.
/// </summary>
public class Tower : MonoBehaviour
{
    [Tooltip("How far this tower can see.")]
    public float radius;

    [Tooltip("How long between each bullet attack (seconds).")]
    public float attackDelay = 1f;

    [Tooltip("The Bullet prefab to fire at targets.")]
    public Bullet bulletPrefab;

    // Store all enemies in range
    private List<Enemy> enemyList = new List<Enemy>();

    private Vector3 position; // this will be the center
    private CircleCollider2D towerRange; 
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        towerRange = GetComponent<CircleCollider2D>();
        towerRange.radius = radius; // Set radius of trigger collider
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        // If there are enemies to shoot and not on cooldown...
        if ((enemyList.Count != 0) && (timer >= attackDelay))
        {
            // Shoot at them
            AttackEnemy();

            // Reset cooldown
            timer = 0;
        }
    }

    // Checks for enemies that enter the radius
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.transform.GetComponent<Enemy>();

        //add enemy to the target list
        if (enemy)
        {
            enemyList.Add(enemy);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Enemy enemy = collision.transform.GetComponent<Enemy>();

        if (enemy)
        {
            enemyList.Remove(enemy);
        }
    }

    /// <summary>
    /// Fire a bullet at the first enemy in the list.
    /// </summary>
    private void AttackEnemy()
    {
        // Get first enemy in List
        // TODO: This behavior should probably change; be chosen by the player
        Enemy enemy = enemyList[0];

        if (!bulletPrefab) { return; }

        // Instantiate the Bullet and set it to follow the target
        Bullet bullet = GameObject.Instantiate(bulletPrefab, position, Quaternion.identity);
        bullet.SetTarget(enemy.transform);

        // Bullet sets itself to yeet after 3 seconds
        Destroy(bullet.gameObject, 3f);
    }
}
