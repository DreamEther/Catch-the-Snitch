using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class AnimController : MonoBehaviour
{
    public Animator anim;
    [SerializeField] bool boostReady = true;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        StartCoroutine(BoostControl());

    }

    IEnumerator BoostControl()
    {
        transform.position = transform.parent.position;
        if (boostReady == true)
        {
            if (CrossPlatformInputManager.GetButtonDown("Boost"))
            {
                anim.Play("Exhaust Trail");
                boostReady = false;
                yield return new WaitForSecondsRealtime(3);
                boostReady = true;

            }
        }
    }

  
}
