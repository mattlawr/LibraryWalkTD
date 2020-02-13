/**
 * Author: Unknown (modified by Matthew Lawrence)
 */
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(SpawnManager))]
public class WaveSpawner : MonoBehaviour
{
    public float timeBetweenWaves = 5.5f;

    public Text timerText;

    private float countdown = 2f;

    private int waveIndex = 1;  // Tracks how many waves have been initiated
    private SpawnManager spawner;

    private void Start()
    {
        spawner = GetComponent<SpawnManager>();
    }

    private void Update ()
    {
        if ( countdown <= 0f )
        {
            // Start co-routine for a single wave
            StartCoroutine( SpawnWave() );

            countdown = timeBetweenWaves; // Reset countdown
        }

        // Decrease countdown every few frames
        countdown -= Time.deltaTime;

        if (!timerText) { return; }
        timerText.text = "Next Wave: " + Mathf.Round(countdown).ToString();
    }

    IEnumerator SpawnWave ()
    {
        int max = waveIndex;

        // Keep waves from spawning too many enemies
        if ( max > 8) {
            max = 8;
        }

        for (int i = 0; i < max; i++)
        {
            spawner.SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }

        waveIndex++;
    }
}
