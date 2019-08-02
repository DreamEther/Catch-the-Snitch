using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerHeart : MonoBehaviour
{

    [SerializeField] AudioClip extraLifePickupSound;
    [SerializeField] [Range(0, 1)] float extraLifePickupSoundVolume;
    bool addExtraHealth;
    HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = FindObjectOfType<HealthBar>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D otherGameObject)
    {
        Player player = otherGameObject.gameObject.GetComponent<Player>();
        if (otherGameObject.gameObject.tag == "player")
        {
            
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(extraLifePickupSound, Camera.main.transform.position, extraLifePickupSoundVolume);
            Player.healthAsPercentage += 0.25f;
            healthBar.SetSize(Player.healthAsPercentage);
            if (Player.healthAsPercentage >= 1)
            {
                Player.healthAsPercentage = 1;
            }


        }
        if (!player)
        {
            addExtraHealth = false;
            return;
        }
    }
}
