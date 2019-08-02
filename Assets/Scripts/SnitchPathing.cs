using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnitchPathing : MonoBehaviour
{
    SnitchConfig snitchConfig;
    List<Transform> snitchWaypoints;
    int speed = 10;

    int waypointIndex = 0;


    void Start()
    {
       
        snitchWaypoints = snitchConfig.GetSnitchWaypoints();
        transform.position = snitchWaypoints[waypointIndex].transform.position;
    }

    void Update()
    {
        Move();
    }

    public void SetSnitchConfig(SnitchConfig snitchConfig)
    {
        this.snitchConfig = snitchConfig;
    }

    public void Move()
    {
        if (waypointIndex <= snitchWaypoints.Count - 1) // -1 because the count doesn't begin at 0 like the the index does. 
        {
            Vector3 lookAt = new Vector3(snitchWaypoints[waypointIndex].transform.position.x, snitchWaypoints[waypointIndex].transform.position.y, this.transform.position.z);
            var lastWaypoint = snitchWaypoints[snitchWaypoints.Count - 1];
            var newRotation = Quaternion.LookRotation(snitchWaypoints[waypointIndex].transform.position - transform.position, Vector3.forward); //we set the upwards rotation to forward, which makes are z axis up and allows us rotate along it 'forwards' aka horizontally
            newRotation.x = 0.0f;
            newRotation.y = 0.0f;
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * speed);

            var targetPosition = snitchWaypoints[waypointIndex].transform.position;
            var movementThisFrame = snitchConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);

            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
            if (transform.position == lastWaypoint.transform.position)
            {
                waypointIndex = 0;
            }
           
        }
        return;

        
    }
}
