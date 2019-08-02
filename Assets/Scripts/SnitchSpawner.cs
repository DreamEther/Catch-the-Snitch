using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnitchSpawner : MonoBehaviour
{

    [SerializeField] List<SnitchConfig> snitchConfigs;
    int snitchConfig = 0;

    // Start is called before the first frame update
    void Start()
    {
        //yield return new WaitForSecondsRealtime(2);
        IterateThroughSnitchConfigs();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void IterateThroughSnitchConfigs()
    {
        for (snitchConfig = 0; snitchConfig < snitchConfigs.Count; snitchConfig++)
        {
            var currentSnitchConfig = snitchConfigs[snitchConfig];
            SpawnAllSnitchesInPhase(currentSnitchConfig);
        }
    }
    private void SpawnAllSnitchesInPhase(SnitchConfig snitchConfig)
    {

        for (int snitchCount = 1; snitchCount <= 1; snitchCount++)
        {
            var enemyClone = Instantiate(snitchConfig.GetSnitchPrefab(), snitchConfig.GetSnitchWaypoints()[0].transform.position, Quaternion.identity);
            enemyClone.GetComponent<SnitchPathing>().SetSnitchConfig(snitchConfig); // using this to pass a value into another waveConfig in EnemyPathing.cs
        }
    }
}
