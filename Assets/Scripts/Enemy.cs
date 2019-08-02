using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] float health = 100f;
    [SerializeField] GameObject enemyDeathParticlePrefab;
    [SerializeField] GameObject hitParticlePrefab;
    [SerializeField] public static float projectileFiringPeriod = 0.5f;
    [SerializeField] AudioClip deathSound;
    [SerializeField] [Range(0,1)] float deathSoundVolume = 0.7f; // the range is from 0 to 1 for 'PlayClipAtPoint's 3rd argument
    [SerializeField] float movementSpeed = 8f;
    [SerializeField] GameObject healthItemPrefab;
    [SerializeField] float timeBeforeHealthDis;
    [SerializeField] float chanceToDropHealth;
    [SerializeField] bool blinkHeart = false;
    [SerializeField] float flickerCountDown;
    GameObject healthItem;

    // Start is called before the first frame update
    void Start()
    {
        
       
    }

    // Update is called once per frame
    void Update()
    {
        
        /*if (blinkHeart == true)
        {
               float t = flickerCountDown--;
               

                if (flickerCountDown % 2 == 0)
                {
                    healthItem.GetComponent<SpriteRenderer>().material.color = Color.clear;
                }
                else
                {
                    healthItem.GetComponent<SpriteRenderer>().material.color = Color.white;
                }
                if (flickerCountDown == 0)
                {
                   healthItem.GetComponent<SpriteRenderer>().material.color = Color.white;
                   Destroy(healthItem);
                   blinkHeart = false;
                }
        }*/
    }

    private void OnTriggerEnter2D(Collider2D otherGameObject)
    {
        DamageDealer damageDealer = otherGameObject.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer)
        {
            return;
        }
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer) // this is saying: 'when anything calls ProcessHit, we need to know who is 'damageDealer'.
    {
        if (damageDealer.gameObject.tag == "Laser")
        {
            damageDealer.gameObject.SetActive(false);
            health -= damageDealer.GetWeaponDamage();
            GameObject explosionParticleEffect = Instantiate(hitParticlePrefab, transform.position, Quaternion.identity) as GameObject;
            Debug.Log(explosionParticleEffect);
            Destroy(explosionParticleEffect, .35f);
        }
        //StartCoroutine(Die());
        Die();
    }

   public void DieUponImpact()
    {
        GameObject explosionParticleEffect = Instantiate(enemyDeathParticlePrefab, transform.position, Quaternion.identity) as GameObject;
        Destroy(gameObject);
        float durationOfExplosion = 0.5f;
        Destroy(explosionParticleEffect, durationOfExplosion);
        AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolume);
    }

  private void Die()
    {
        if (health <= 0)
        {
            GameTimer.startTimer += 1;
            GameObject explosionParticleEffect = Instantiate(enemyDeathParticlePrefab, transform.position, Quaternion.identity) as GameObject;
            Destroy(gameObject);
            float durationOfExplosion = 1f;
            Destroy(explosionParticleEffect, durationOfExplosion);
            AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolume);
            chanceToDropHealth = Random.Range(0, 1.0f);
            if (chanceToDropHealth >= .60f)
            {
                GameObject healthItem = Instantiate(healthItemPrefab, transform.position, Quaternion.identity) as GameObject;
                Destroy(healthItem, 5);
                //yield return new WaitForSecondsRealtime(3);

                //Debug.Log("BLINK HEART IS TRUE");
                //blinkHeart = true;

                //
            }
        }


            
    }


            // using transform.position would make the sound lose power due to the audio
            //being played in a 3D space. So, instead we are playing audio where the main camera resides
            //which is where the audio listener is. 
        
    

    

    public void DieWithSnitch()
    {
        GameObject explosionParticleEffect = Instantiate(enemyDeathParticlePrefab, transform.position, Quaternion.identity) as GameObject;
        Destroy(gameObject);
        float durationOfExplosion = 0.5f;
        Destroy(explosionParticleEffect, durationOfExplosion);
        AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolume);

    }
}