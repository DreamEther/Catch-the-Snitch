using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "MainCamera")
        {

            if (gameObject.tag == "Laser" || gameObject.tag == "Laser Right" || gameObject.tag == "Laser Left")
            {
                gameObject.SetActive(false);
            }
            else
            {
                Destroy(gameObject);
            }
        }
            
        
    }
}

