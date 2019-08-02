using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEnter : MonoBehaviour
{

    Player player;
    HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        healthBar = FindObjectOfType<HealthBar>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        DamageDealer damageDealer = player.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer)
        {
            return;
        }
        HitPlayer(damageDealer);

    }

    private void HitPlayer(DamageDealer damageDealer)
    {
        if (damageDealer.gameObject.tag == "player")
        {
            if (Player.healthAsPercentage > 0)
            {
                Debug.Log("Detecting Player");

                Player.healthAsPercentage -= 0.25f;
                healthBar.SetSize(Player.healthAsPercentage);
            }
            
        }
        player.Die();

    }
}
