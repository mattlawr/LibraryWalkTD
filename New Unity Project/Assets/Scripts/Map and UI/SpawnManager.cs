using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Path[] paths;    // The set of Paths for this level. ?Generate based on children?
    public float rate = 5f; // 1 enemy every x seconds
    
    public Enemy enemy; // Use random enemy from array ***

    private float rateTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(rateTimer >= rate)   // Spawn enemy at certain rate
        {
            SpawnEnemy();
            rateTimer = 0f;
        }

        rateTimer += Time.deltaTime;
    }

    public void SpawnEnemy()
    {
        int i = Random.Range(0, paths.Length);

        Path currPath = paths[i];   // Random path

        Enemy e = Instantiate(enemy, currPath.transform.position, currPath.transform.rotation, null);

        e.SetPath(currPath);
    }
}
