using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class BulletHellTrigger : MonoBehaviour
{
    Coroutine firingCoroutine;
    [HideInInspector] public float projectileFiringPeriod = 0.5f;
    [SerializeField] bool spawnExtraBullets = false;
    [SerializeField] bool bulletHellReady = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(SpawnExtraBullets());
        FireExtraContinuosly();
    }

    public void FireExtraContinuosly()
    {
        if (spawnExtraBullets == true)
        {
            if (CrossPlatformInputManager.GetButtonDown("Fire1"))
            {
                firingCoroutine = StartCoroutine(FireExtra());
            }
            if (CrossPlatformInputManager.GetButtonUp("Fire1"))
            {
                StopCoroutine(firingCoroutine);
            }
        }
        else if (spawnExtraBullets == false)
        {
            StopAllCoroutines();
        }
    }
    public IEnumerator FireExtra()
    {                                                // Quaternion.identity is simply saying - 'keep rotation as is'

        while(true)
        {
            GameObject laserLeft = ObjectPooler.SharedInstance.GetPooledObject("Laser Left");
            GameObject laserRight = ObjectPooler.SharedInstance.GetPooledObject("Laser Right");
            if (laserLeft != null && laserRight != null)
            {

                GameObject spawnPointLeft = transform.Find("Spawn Bullet Left").gameObject;
                GameObject spawnPointRight = transform.Find("Spawn Bullet Right").gameObject;
                laserLeft.transform.position = spawnPointLeft.transform.position;
                laserLeft.transform.rotation = spawnPointLeft.transform.rotation;
                laserLeft.gameObject.SetActive(true);

                laserRight.transform.position = spawnPointRight.transform.position;
                laserRight.transform.rotation = spawnPointRight.transform.rotation;
                laserRight.gameObject.SetActive(true);
            }
            yield return new WaitForSecondsRealtime(projectileFiringPeriod);
        }        
           

    }

   IEnumerator SpawnExtraBullets()
    {
        if (bulletHellReady == true)
        {
            if (CrossPlatformInputManager.GetButtonDown("Bullet Hell"))
            {
               spawnExtraBullets = true;
               bulletHellReady = false;
               yield return new WaitForSecondsRealtime(7);
               spawnExtraBullets = false;
               bulletHellReady = true;
            }
        }
    }
}
