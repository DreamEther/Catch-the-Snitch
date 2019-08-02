using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExhaustAnimation : MonoBehaviour
{

    

   
 


 public void AdjustPositionAccordingToParent()
    {
        
        transform.position = transform.parent.position;
        var newVector = new Vector3(0, 0, -90);
        transform.Rotate(newVector, Space.World);
    }

    /* This function is trigger at the end of the animation */
    public void Update()
    {
     
    }
// Start is called before the first frame update
void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
   
        
    }

}
