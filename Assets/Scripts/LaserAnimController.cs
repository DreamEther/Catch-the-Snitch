using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserAnimController : MonoBehaviour
{

    [SerializeField] AudioClip laserCharging;
    [SerializeField] [Range(0, 1)] float laserVolume;
    public Animator anim;
    [SerializeField] int recoveryTime = 2;
    Vector3 distanceToPlayer;
    Player player;
    int accuracy = 10;
    public bool looping = true;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        distanceToPlayer = new Vector3(0, 0, 0);
        player = FindObjectOfType<Player>();

        do
        {
            yield return StartCoroutine(LockLaserToParent());
        }
        while (looping);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.parent.position;
    }

    IEnumerator LockLaserToParent()
    {
        Vector3 distanceToPlayer = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        var direction = player.transform.position - distanceToPlayer;

        if (direction.magnitude < accuracy)
        {
            AudioSource.PlayClipAtPoint(laserCharging, Camera.main.transform.position, laserVolume);
            anim.Play("Laser Beam");
            yield return new WaitForSecondsRealtime(recoveryTime);
        }
        
    }
}

