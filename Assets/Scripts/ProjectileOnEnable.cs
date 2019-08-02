using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileOnEnable : MonoBehaviour
{
    private Rigidbody2D objectRigidbody;
    public float speed;

    private void Awake()
    {
        
    }

    private void OnEnable()
    {
        objectRigidbody = GetComponent<Rigidbody2D>();
        objectRigidbody.AddForce(transform.up * speed);
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
