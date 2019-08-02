using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderProjectileBehavior : MonoBehaviour
{

    [SerializeField] float minTimeBetweenShots = 3f;
    [SerializeField] float maxTimeBetweenShots = 5f;
    [SerializeField] public static float projectileSpeed = 50f;
    [SerializeField] AudioClip laserSound;
    [SerializeField] [Range(0, 1)] float laserSoundVolume = 0.25f;
    Player player;

    // Start is called before the first frame update
    void Start()
    {

        InvokeRepeating("Fire", 2, RandomShotCounter());
        player = FindObjectOfType<Player>();

    }

    // Update is called once per frame
    void Update()
    {

        RandomShotCounter();
    }



    private void Fire()
    {
        GameObject clusterProjectileSpawn = ObjectPooler.SharedInstance.GetPooledObject("cluster projectile") as GameObject;
        if (clusterProjectileSpawn != null)
        {
            GameObject spawnPointLeft = transform.Find("spawn cluster").gameObject;
        

            AudioSource.PlayClipAtPoint(laserSound, player.transform.position, laserSoundVolume);
            clusterProjectileSpawn.transform.position = spawnPointLeft.transform.position;
            clusterProjectileSpawn.transform.rotation = spawnPointLeft.transform.rotation;
            clusterProjectileSpawn.gameObject.SetActive(true);
        }

    }

    private int RandomShotCounter()
    {
        int randomRange = Random.Range(4, 8);
        return randomRange;
    }
}