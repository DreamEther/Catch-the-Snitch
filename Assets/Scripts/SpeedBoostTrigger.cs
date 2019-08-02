using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class SpeedBoostTrigger : MonoBehaviour
{

    [HideInInspector] public float addedForce = 50f;
    bool boostReady = true;
    [SerializeField] AudioClip boostSoundEffect;
    [SerializeField] [Range(0, 1)] float boostSoundVolume = 0.25f;

    public IEnumerator InitiateSpeedBoost()
    {
        if (boostReady)
        {
            if (CrossPlatformInputManager.GetButtonDown("Boost"))
            {
                AudioSource.PlayClipAtPoint(boostSoundEffect, Camera.main.transform.position, boostSoundVolume);
                GetComponent<Rigidbody2D>().velocity = this.transform.up * 10;
                boostReady = false;
                yield return new WaitForSecondsRealtime(1);
                GetComponent<Rigidbody2D>().velocity = this.transform.up / 10;
                yield return new WaitForSecondsRealtime(2);
                boostReady = true;
            }
        }
    }   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        StartCoroutine(InitiateSpeedBoost());
    }
}
