using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationForImports : MonoBehaviour
{

    [SerializeField] float rotationSpeed = 8f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateTowardsPlayer();
    }

    private void RotateTowardsPlayer()

    {

        Rigidbody2D rigidBody;
        Player target;


        rigidBody = GetComponent<Rigidbody2D>();
        target = GameObject.FindObjectOfType<Player>();

        var newRotation = Quaternion.LookRotation(target.transform.position - transform.position, Vector3.forward * -1); //we set the upwards rotation to forward, which makes are z axis up and allows us rotate along it 'forwards' aka horizontally
        newRotation.x = 0.0f;
        newRotation.y = 0.0f;
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * rotationSpeed); // this is to smooth out the rotation speed so the gameObject doesn't immediately snap to the target
    }
}
