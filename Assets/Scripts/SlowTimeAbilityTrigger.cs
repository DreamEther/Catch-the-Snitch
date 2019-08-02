using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class SlowTimeAbilityTrigger : MonoBehaviour
{
    [HideInInspector] public float timeScale = 0.5f;
    public bool slowTimeReady = true;
    [HideInInspector] public float slowTimeCooldown;
    // [SerializeField] AudioClip slowTimeSoundEffect;
    //[SerializeField] [Range(0, 1)] float slowTimeVolume;
    Rigidbody2D rigidBody;
    [SerializeField] float slowTimeProjectileSpeed = 1000f;
    Player player;


    public void Start()
    {
        
    }
    public void Update()
    {

        StartCoroutine(SlowTime());
        //Debug.Log(Time.timeScale);
        Time.timeScale += (1f / 10f) * Time.unscaledDeltaTime; // once we slow time with the trigger press, Time.timeScale, which is clamped between 0 and 1, becomes 0.5, and each time Update is called we slowly add to that value into real time is resumed. 
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
       

      
      
    }

    public IEnumerator SlowTime()
    {
        if (slowTimeReady == true)
        {
            if (CrossPlatformInputManager.GetButtonDown("Slow Time"))
            {

                // AudioSource.PlayClipAtPoint(slowTimeSoundEffect, Camera.main.transform.position, slowTimeVolume);
                slowTimeReady = false;
                Time.timeScale = timeScale;
                Time.fixedDeltaTime = Time.timeScale * 0.02f;
               // player.laser.GetComponent<Rigidbody2D>().AddForce(transform.up * slowTimeProjectileSpeed);
                yield return new WaitForSecondsRealtime(slowTimeCooldown);
                slowTimeReady = true;
            }
        }
        
    }

   
}
