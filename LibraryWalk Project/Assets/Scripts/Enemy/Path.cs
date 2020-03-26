/**
 * Path.cs (Previously called Waypoints.cs)
 * Handles a single set of positions for an enemy to walk through
 * 
 * The sequence of children for THIS object will determine the points of this Path
 * 
 * Derived from TowerDefenseTutorial
 * Author: Matthew Lawrence
 */
using UnityEngine;

/// <summary>
/// Stores an ordered array of points that represent a pathway through the map.
/// </summary>
public class Path : MonoBehaviour
{
    [System.NonSerialized]
    public Transform[] points;  // Set by this class, not from the inspector

    void Awake()
    {
        points = new Transform[transform.childCount];

        // Loop through each child for each Path point
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }

    }
}
