using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{

    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] bool looping = false;
    int startingWave = 0;
    public static GameObject enemyClone;
    Snitch snitch;
    WaveConfig waveConfig;
    GameObject[] snitches;



    // Start is called before the first frame update
    IEnumerator Start() //IEnumerator so we can use it as a Coroutine.
    {
        yield return new WaitForSecondsRealtime(1);
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        }
        while (looping);
    }

    private void Update()
    {

    }

    private IEnumerator SpawnAllWaves()
    {
        for (int waveIndex = startingWave; waveIndex < waveConfigs.Count; waveIndex++)
        {
            var currentWave = waveConfigs[waveIndex];
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
            yield return new WaitForSeconds(1);
            //last line is essentially saying: "don't do this method until the SpawnAllEnemiesInWave Coroutine is finished. 
        }
    }
    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        
        for (int enemyCount = 0; enemyCount < waveConfig.GetNumberOfEnemies(); enemyCount++)
        {

            var enemyClone = Instantiate(waveConfig.GetEnemyPrefab(), waveConfig.GetWaypoints()[0].transform.position, Quaternion.identity);
            enemyClone.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig); // using this to pass a value into another waveConfig in EnemyPathing.cs
            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());



        }
    }

}

