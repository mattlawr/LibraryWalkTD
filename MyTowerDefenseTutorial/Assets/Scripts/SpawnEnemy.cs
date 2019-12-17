﻿using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public int health = 10;
    public float speed = 10f;

    private Transform target;
    public int wavepointIndex = 0;

    private void Start()
    {
        target = Waypoints.points[wavepointIndex];
    }

    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
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