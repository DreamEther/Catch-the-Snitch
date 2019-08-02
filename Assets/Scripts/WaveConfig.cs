using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


[CreateAssetMenu(menuName = "Wave")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab; // this is GameObject so that we can attach a game object in Unity
    [SerializeField] GameObject wavePrefab; // this is GameObject so that we can attach a game object in Unity
    [SerializeField] float timeBetweenSpawns = 0.5f;
    [SerializeField] float spawnRandomFactor = 0.3f;
    [SerializeField] int numberOfEnemies = 5;
    [SerializeField] float moveSpeed = 2f;


    public GameObject GetEnemyPrefab()
    {
        return enemyPrefab;
    }

    public List<Transform> GetWaypoints() // we do this because we want to return the waypoints under the path prefab, not just the path prefab
    { // we're returning a list of transforms, so we need to create a variable which is a new list of transforms. 
        var waveWaypoints = new List<Transform>();
        // path is parent, children are waypoints
        foreach (Transform child in wavePrefab.transform) //foreach code for retrieving the child gameobjects from pathPrefab
        {
            waveWaypoints.Add(child);
        }

        return waveWaypoints;
    }

    public float GetTimeBetweenSpawns()
    {
        return timeBetweenSpawns;
    }

    public float GetSpawnRandomFactor()
    {
        return spawnRandomFactor;
    }

    public int GetNumberOfEnemies()
    {
        return numberOfEnemies;
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

}
