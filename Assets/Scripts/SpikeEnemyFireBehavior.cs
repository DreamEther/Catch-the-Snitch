using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeEnemyFireBehavior : MonoBehaviour
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
        // CountDownAndShoot();
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
        GameObject enemyLaserLeftSpawn = ObjectPooler.SharedInstance.GetPooledObject("spike laser left") as GameObject;
        GameObject enemyLaserRightSpawn = ObjectPooler.SharedInstance.GetPooledObject("spike laser right") as GameObject;
        if (enemyLaserLeftSpawn != null && enemyLaserRightSpawn != null)
        {
            GameObject spawnPointLeft = transform.Find("Green Laser Left Spawn").gameObject;
            GameObject spawnPointRight = transform.Find("Green Laser Right Spawn").gameObject;

            AudioSource.PlayClipAtPoint(laserSound, player.transform.position, laserSoundVolume);
            enemyLaserLeftSpawn.transform.position = spawnPointLeft.transform.position;
            enemyLaserLeftSpawn.transform.rotation = spawnPointLeft.transform.rotation;
            enemyLaserLeftSpawn.gameObject.SetActive(true);


            enemyLaserRightSpawn.transform.position = spawnPointRight.transform.position;
            enemyLaserRightSpawn.transform.rotation = spawnPointRight.transform.rotation;
            enemyLaserRightSpawn.gameObject.SetActive(true);


        }

    }

    private int RandomShotCounter()
    {
        int randomRange = Random.Range(2, 6);
        return randomRange;
    }
}