using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeetleProjectileBehavior: MonoBehaviour
{
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 3f;
    [SerializeField] float maxTimeBetweenShots = 5f;
    [SerializeField] public static float projectileSpeed = 50f;
    [SerializeField] AudioClip orbSound;
    [SerializeField] [Range(0, 1)] float orbSoundVolume = 0.25f;
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
        GameObject blueHeavy = ObjectPooler.SharedInstance.GetPooledObject("blue heavy") as GameObject;
        GameObject greenHeavy = ObjectPooler.SharedInstance.GetPooledObject("green heavy") as GameObject;
        GameObject orangeHeavy = ObjectPooler.SharedInstance.GetPooledObject("orange heavy") as GameObject;
        GameObject pinkHeavy = ObjectPooler.SharedInstance.GetPooledObject("pink heavy") as GameObject;

        if (blueHeavy != null && greenHeavy != null && orangeHeavy != null && pinkHeavy != null)
        {
            
            GameObject spawnBlueHeavy = transform.Find("spawn orb").gameObject;
            GameObject spawnGreenHeavy = transform.Find("spawn orb").gameObject;
            GameObject spawnPinkHeavy = transform.Find("spawn orb").gameObject;
            GameObject spawnOrangeHeavy = transform.Find("spawn orb").gameObject;

            GameObject[] orbs = new GameObject[4];
            orbs[0] = blueHeavy;
            orbs[1] = greenHeavy;
            orbs[2] = orangeHeavy;
            orbs[3] = pinkHeavy;
            AudioSource.PlayClipAtPoint(orbSound, player.transform.position, orbSoundVolume);
            blueHeavy.transform.position = spawnBlueHeavy.transform.position;
            blueHeavy.transform.rotation = spawnBlueHeavy.transform.rotation;

            greenHeavy.transform.position = spawnGreenHeavy.transform.position;
            greenHeavy.transform.rotation = spawnGreenHeavy.transform.rotation;

            orangeHeavy.transform.position = spawnOrangeHeavy.transform.position;
            orangeHeavy.transform.rotation = spawnOrangeHeavy.transform.rotation;

            pinkHeavy.transform.position = spawnPinkHeavy.transform.position;
            pinkHeavy.transform.rotation = spawnPinkHeavy.transform.rotation;

            var randomOrb = orbs[Random.Range(0, orbs.Length)];
            randomOrb.SetActive(true);
          
           
        }

    }

    private int RandomShotCounter()
    {
        int randomRange = Random.Range(6, 10);
        return randomRange;
    }

}
