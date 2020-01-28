using UnityEngine;

/**
 * Path.cs (Previously called Waypoints.cs)
 * Handles a single set of positions for an enemy to walk through
 * 
 * Derived from TowerDefenseTutorial
 */
public class Path : MonoBehaviour
{
    public Transform[] points;

    void Awake()
    {
        points = new Transform[transform.childCount];
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }

    }
}
