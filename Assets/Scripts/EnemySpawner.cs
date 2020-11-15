using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<WaveConfig> waveConfigs = new List<WaveConfig>();
    [SerializeField] private bool enemyLooping = false;
    private int startingWave = 0;

    // Start is called before the first frame update
    private IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        } while (enemyLooping);
        
    }
    private IEnumerator SpawnAllWaves()
    {
        for (int i = startingWave; i < waveConfigs.Count; i++ )
        {
            var currentWave = waveConfigs[i];
            yield return StartCoroutine(SpawnAllEnemies(currentWave));
        }
    }
    private IEnumerator SpawnAllEnemies(WaveConfig wave)
    {
        for (int i =0; i < wave.NumberOfEnemies; i++)
        {
            var newEnemy = Instantiate(wave.EnemyPrefab, wave.GetWayPoints[0].transform.position, Quaternion.identity);

            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(wave);
            yield return new WaitForSeconds(wave.TimeBetweenSpawns);
        }
        
    }

}
