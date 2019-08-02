using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    WaveConfig waveConfig;
    List<Transform> waypoints;
    int enemyCount = 0;
    float enemySpeed = 5f;
    int waypointIndex = 0;
    Rigidbody2D rigidBody;
    Enemy enemy;
    int repelRange = 5;
    int accuracy = 1;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void SetWaveConfig(WaveConfig waveConfig) // waveConfig here is a slightly different variable from the one we are using elsewhere. It's acting as a setter for which we can call in another script
    {
        this.waveConfig = waveConfig; // first waveConfig is referencing our variable at the top of the script
        //second waveConfig is the variable that we are going to receive in the parameter of this method.
    }
    public void Move()
    {
        if (waypointIndex < waypoints.Count - 1) // -1 because the count doesn't begin at 0 like the the index does. 
        {
            if (waypoints == null)
            {
                return;
                    }
                var lastWaypoint = waypoints[waypoints.Count - 1];
                var targetPosition = waypoints[waypointIndex].transform.position;
                var movementThisFrame = waveConfig.GetMoveSpeed() * Time.deltaTime;
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
        /*else
        { 
            Player player = FindObjectOfType<Player>();
            
            Vector2 distanceFromPlayer = (transform.position - player.transform.position);
            
               /* if (distanceFromPlayer.magnitude > accuracy)
                    {
                         transform.position = Vector3.MoveTowards(transform.position, player.transform.position, enemySpeed * Time.deltaTime);
                    
                    }
                //Vector2 newPos = transform.position + transform.right * Time.fixedDeltaTime * enemySpeed;
                //transform.position = newPos;

        } */


    }


}





