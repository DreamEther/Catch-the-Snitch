using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{

    Rigidbody2D rigidBody;
    float moveSpeed = 7f;
    Player target;
    Vector2 movedDirection;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {

        moveSpeed = Random.Range(4f, 10f);
    }

    private void OnEnable()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        target = GameObject.FindObjectOfType<Player>();
        movedDirection = (target.transform.position - transform.position +- offset).normalized * moveSpeed;
        rigidBody.velocity = new Vector2(movedDirection.x, movedDirection.y) * 2f;
    }

    // Update is called once per frame
    void Update()
    {
        
        float randomX = Random.Range(0, 5);
        float randomY = Random.Range(0, 5);
        offset = new Vector3(randomX, randomY, 0);
        moveSpeed = Random.Range(4f, 10f);
    }
}
