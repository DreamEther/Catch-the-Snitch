using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEnterForceField : MonoBehaviour
{
    Player player;
    HealthBar healthBar;
    int force = 4;
    Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = transform.parent.position;
        rb.MovePosition(transform.parent.position);
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Laser")
        {
            other.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            if (Player.healthAsPercentage > 0)
            {
                Player.healthAsPercentage -= 0.05f;
                healthBar.SetSize(Player.healthAsPercentage);
            }
            player.Die();
        }
    }
}

    




