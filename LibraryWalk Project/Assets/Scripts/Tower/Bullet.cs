/**
 * Bullet.cs
 * Author: Matthew Lawrence
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public enum damageType { Health, Slowdown };
    public enum bulletType { Contact, Area };

    public float speed = 1f;
    public bulletType type = bulletType.Contact;
    public damageType damage = damageType.Health;
    public int strength = 1;
    public float lifetime = 3f;
    public bool destroyOnHit = true;

    Transform target;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifetime);

        // Check an area for enemies
        if(type == bulletType.Area)
        {
            foreach(Collider2D c in Physics2D.OverlapCircleAll(transform.position, speed))
            {
                HitTarget (c.transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!target) {
            Destroy(gameObject); return;
        }

        if (type != bulletType.Contact)
            return;

        // Follow target
        transform.Translate((target.position - transform.position).normalized * speed);

        if(Vector3.Distance(target.position, transform.position) < 0.5f)
        {
            HitTarget(target);
        }
    }

    /*// Collision isn't working?!
    private void OnCollisionEnter2D(Collision2D other)
    {
        HitTarget(other.transform);
    }*/

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
            switch (damage)
            {
                case damageType.Health:
                    enemy.TakeDamage(strength);
                    break;
                case damageType.Slowdown:
                    enemy.Slow(strength);
                    break;
                default:
                    break;
            }

            if (destroyOnHit)
            {
                Destroy(gameObject);
            }
        }
    }
}
