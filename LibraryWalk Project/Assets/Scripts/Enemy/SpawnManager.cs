/**
 * SpawnManager.cs
 * Author: Library Walk TD
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that spawns Enemy objects on a map using given Paths.
/// </summary>
public class SpawnManager : MonoBehaviour
{
    /// <summary>
    /// Throw every Path object in here so the class knows that they exist.
    /// </summary>
    public Path[] paths;    // The set of Paths for this level. ?Generate based on children?

    /// <summary>
    /// Spawn 1 enemy every x seconds (set to zero for no constant students).
    /// </summary>
    public float spawnRate = 5f;

    /// <summary>
    /// The prefab to spawn at a given Path.
    /// </summary>
    public Enemy[] enemyPrefabs;

    private float rateTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Spawn enemy at certain rate
        if (spawnRate > 0f && rateTimer >= spawnRate)
        {
            SpawnEnemy();
            rateTimer = 0f;
        }

        rateTimer += Time.deltaTime;
    }

    /// <summary>
    /// Spawn an enemy at a random path.
    /// </summary>
    public void SpawnEnemy(int lvl = 1)
    {
        // Random path chosen from array
        int i = Random.Range(0, paths.Length);
        Path currPath = paths[i];

        // Spawn random enemy object (uses lvl parameter to choose from array, tied to current wave)
        int randomEnemy = Mathf.Clamp(Random.Range(0, lvl/2), 0, enemyPrefabs.Length - 1);
        Enemy en = Instantiate(enemyPrefabs[randomEnemy], currPath.transform.position, currPath.transform.rotation, null);

        // Tell the enemy to follow the chosen Path
        en.SetPath(currPath);
    }
}
