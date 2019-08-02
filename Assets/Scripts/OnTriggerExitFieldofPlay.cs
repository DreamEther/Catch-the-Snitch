using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerExitFieldofPlay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "boundary")
        {
            if (gameObject.tag == "mutant beam" || gameObject.tag == "spike laser left" ||gameObject.tag == "spike laser right" || gameObject.tag == "blue heavy"
                || gameObject.tag == "pink heavy" || gameObject.tag == "green heavy" || gameObject.tag == "orange heavy" || gameObject.tag == "cluster projectile")
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
