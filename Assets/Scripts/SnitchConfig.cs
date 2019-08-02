using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Snitch")]
public class SnitchConfig : ScriptableObject
{

    [SerializeField] GameObject snitchPrefab;
    [SerializeField] GameObject snitchRoute;
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] int numberOfSnitches = 1;


    public int GetNumberOfSnitches()
    {
        return numberOfSnitches;
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public GameObject GetSnitchPrefab()
    {
        return snitchPrefab;
    }

    public List<Transform> GetSnitchWaypoints()
    {
        var snitchWaypoints = new List<Transform>();

        foreach (Transform child in snitchRoute.transform)
        {
            snitchWaypoints.Add(child);
        }

        return snitchWaypoints;
    }
}
