using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    //for all towers
    public float radius;
    public float attackDelay = 1f;

    public Bullet bulletPrefab;

    // Store all enemies in range
    private List<Enemy> enemyList = new List<Enemy>();

    private Vector3 position; // this will be the center
    private CircleCollider2D towerRange; 
    private float timer = 0f;

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

    // Fire a bullet at the first enemy in the list
    private void AttackEnemy()
    {
        Enemy enemy = enemyList[0];

        if (!bulletPrefab) { return; }

        Bullet bullet = GameObject.Instantiate(bulletPrefab, position, Quaternion.identity);
        bullet.SetTarget(enemy.transform);

        // bullet will yeet
        Destroy(bullet.gameObject, 3f);
    }

    //----------------------------------------------------------------------------

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        towerRange = GetComponent<CircleCollider2D>();
        towerRange.radius = radius;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        // If there are enemies to shoot...
        if ((enemyList.Count != 0) && (timer >= attackDelay)) {
            // Shoot at them
            AttackEnemy();

            // Reset cooldown
            timer = 0;
        }
    }
}
