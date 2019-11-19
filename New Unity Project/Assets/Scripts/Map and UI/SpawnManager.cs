using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] spawns;// Generate randomly...?
    public float rate = 5f;// 1 enemy every x seconds
    private float rateTimer = 0f;
    public GameObject enemy;// Use random enemy from array ***

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(rateTimer >= rate)
        {
            SpawnEnemy();
            rateTimer = 0f;
        }

        rateTimer += Time.deltaTime;
    }

    public void SpawnEnemy()
    {
        int spnt = Random.Range(0, spawns.Length);
        int dest = Random.Range(0, spawns.Length);

        if(spawns.Length > 1)
        {
            while(dest == spnt)
            {
                dest = Random.Range(0, spawns.Length);
            }
        }

        GameObject go = Instantiate(enemy, spawns[spnt].transform.position, spawns[spnt].transform.rotation, null);

        go.GetComponent<MoveManagerPath>().pointOneX = spawns[spnt].transform.position.x;
        go.GetComponent<MoveManagerPath>().pointOneY = spawns[spnt].transform.position.y;
        go.GetComponent<MoveManagerPath>().pointTwoX = spawns[dest].transform.position.x;
        go.GetComponent<MoveManagerPath>().pointTwoY = spawns[dest].transform.position.y;
    }
}
