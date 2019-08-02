using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Orb1 : MonoBehaviour
{

    public Colors selectColor;

    // Start is called before the first frame update
    private void Start()
    {
        ChangeColor();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void ChangeColor()
    {
        GetComponent<SpriteRenderer>().material.color = selectColor.GetColor("Blue"); // we can use this method because it returns a string, and 'GetColor' requires a string field. 
        GetComponentInChildren<Image>().color = GetComponent<SpriteRenderer>().material.color; // if you use material.color it changes every object with a material to green for some reason.
        GetComponentInChildren<SpriteRenderer>().material.color = GetComponent<SpriteRenderer>().material.color;
    }

  
}
