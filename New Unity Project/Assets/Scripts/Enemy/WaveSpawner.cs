/**
 * Author: Unknown (modified by Matthew Lawrence)
 */
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(SpawnManager))]
public class WaveSpawner : MonoBehaviour
{
    public int timeBetweenWaves = 5;

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
        // Decrease countdown every few frames
        countdown -= Time.deltaTime;

        string nextWave = Mathf.Floor(countdown % 60).ToString("0");

        if ( countdown <= 0f )
        {
            countdown = timeBetweenWaves - Time.deltaTime; // Reset countdown
            nextWave = 0.ToString();

            // Start co-routine for a single wave
            StartCoroutine( SpawnWave() );
        }

        if (!timerText) { return; }
        timerText.text = nextWave;
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

        // Temporary
        GameManager.instance.UpdateLevel(waveIndex);
    }
}
