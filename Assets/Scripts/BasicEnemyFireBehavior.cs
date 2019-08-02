using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyFireBehavior : MonoBehaviour
{

    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 3f;
    [SerializeField] float maxTimeBetweenShots = 5f;
    [SerializeField] public static float projectileSpeed = 50f;
    [SerializeField] AudioClip laserSound;
    [SerializeField] [Range(0, 1)] float laserSoundVolume = 0.25f;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        InvokeRepeating("Fire", 2, RandomShotCounter());
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
         //CountDownAndShoot();
        RandomShotCounter();
    }

    private void CountDownAndShoot()
    {
        //Time.deltaTime makes it so that the shot is framerate independent. 
        shotCounter -= Time.deltaTime; // shotCounter - (the time that our frame takes to complete)
        if (shotCounter <= 0f)
        {
            Fire();
           
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }


    private void Fire()
    {
        GameObject enemyLaser = ObjectPooler.SharedInstance.GetPooledObject("mutant beam");
        if (enemyLaser != null)
        {
            AudioSource.PlayClipAtPoint(laserSound, player.transform.position, laserSoundVolume);
            enemyLaser.transform.position = transform.position;
            enemyLaser.transform.rotation = transform.rotation;
            enemyLaser.SetActive(true);
        }
       
        //GameObject enemyLaser = Instantiate(enemyLaserPrefab, transform.position, transform.rotation) as GameObject; // transform.position because that is the position of the player ship, which has a pivot point at its center.
        //enemyLaser.GetComponent<Rigidbody2D>().AddForce(transform.up * projectileSpeed);
        //AudioSource.PlayClipAtPoint(laserSound, Camera.main.transform.position, laserSoundVolume);
    }

    private int RandomShotCounter()
    {
        int randomRange = Random.Range(5, 10);
        return randomRange;
    }
}
