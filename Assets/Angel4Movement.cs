using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Angel4Movement : MonoBehaviour
{
    int currentWP = 0;

    float speed = 2f;
    float accuracy = .3f;

    GameObject[] waypoints;
    // Start is called before the first frame update
    void Start()
    {
        waypoints = GameObject.FindGameObjectsWithTag("angel 4");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LateUpdate()
    {



        if (waypoints.Length == 0)
        {
            return;
        }
        Vector3 lookAt = new Vector3(waypoints[currentWP].transform.position.x, waypoints[currentWP].transform.position.y, this.transform.position.z);
        var direction = lookAt - transform.position;

        var newRotation = Quaternion.LookRotation(waypoints[currentWP].transform.position - transform.position, Vector3.forward); //we set the upwards rotation to forward, which makes are z axis up and allows us rotate along it 'forwards' aka horizontally
        newRotation.x = 0.0f;
        newRotation.y = 0.0f;
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * speed);


        if (direction.magnitude < accuracy)
        {
            currentWP++;
            if (currentWP >= waypoints.Length)
            {
                currentWP = 0;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, lookAt, speed * Time.deltaTime);
    }
}