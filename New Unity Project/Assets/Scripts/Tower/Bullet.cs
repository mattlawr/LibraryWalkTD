/**
 * Bullet.cs
 * Author: Matthew Lawrence
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 1f;
    public int damage = 1;

    Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!target) {
            Destroy(gameObject); return;
        }

        // Follow target
        transform.Translate((target.position - transform.position).normalized * speed);

        if(Vector3.Distance(target.position, transform.position) < 0.5f)
        {
            HitTarget(target);
        }
    }

    // Collision isn't working?!
    private void OnCollisionEnter2D(Collision2D other)
    {
        HitTarget(other.transform);
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    /// <summary>
    /// Deal damage and remove self from existence.
    /// </summary>
    /// <param name="hit">Target to deal damage to.</param>
    void HitTarget(Transform hit)
    {
        Enemy enemy = hit.transform.GetComponent<Enemy>();

        // Deal damage
        if (enemy)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
