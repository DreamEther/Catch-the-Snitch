using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Orb3 : MonoBehaviour
{
    private int randomValue;
    public Colors selectColor;
    bool looping = true;
    GameObject redSnitch;
    GameObject blueSnitch;
    GameObject greenSnitch;

    private void Awake()
    {
        //var randomizeTimeBetweenColorChange = Random.Range(1, 3);
        // InvokeRepeating("ChangeColor", 0, randomizeTimeBetweenColorChange);
    }
    // Start is called before the first frame update
    IEnumerator Start()
    {
      
        // orbImage = FindObjectOfType<OrbUI>();
        do
        {
            InvokeRepeating("RandomTimeBeforeColorChange", 0, 0);
            InvokeRepeating("RandomTimeBeforeColorChange2", 0, 0);
            InvokeRepeating("RandomTimeBeforeColorChange3", 0, 0);
            InvokeRepeating("RandomTimeBeforeColorChange", 0, 0);
            //InvokeRepeating("RandomColorIndex", 0, 0);
          //  InvokeRepeating("RandomColorIndex2", 0, 0);
            //InvokeRepeating("RandomColorIndex3", 0, 0);
            yield return StartCoroutine(ChangeColor()); // need the yield return or else unity will crash with the while loop.
        }
        while (looping);
    }

    private void Update()
    {
        RandomColorIndex();
        blueSnitch = GameObject.FindGameObjectWithTag("blue snitch");
        redSnitch = GameObject.FindGameObjectWithTag("red snitch");
        greenSnitch = GameObject.FindGameObjectWithTag("green snitch");
    }

    IEnumerator ChangeColor()
    {
        
        GetComponent<SpriteRenderer>().material.color = selectColor.GetColor(RandomColorIndex()); // we can use this method because it returns a string, and 'GetColor' requires a string field.     
        GetComponentInChildren<Image>().color = GetComponent<SpriteRenderer>().material.color; // if you use material.color it changes every object with a material to green for some reason.

        yield return new WaitForSecondsRealtime(RandomTimeBeforeColorChange());

       
        GetComponent<SpriteRenderer>().material.color = selectColor.GetColor(RandomColorIndex()); // blue       
        GetComponentInChildren<Image>().color = GetComponent<SpriteRenderer>().material.color;


        yield return new WaitForSecondsRealtime(RandomTimeBeforeColorChange2());

        
        GetComponent<SpriteRenderer>().material.color = selectColor.GetColor(RandomColorIndex());
        GetComponentInChildren<Image>().color = GetComponent<SpriteRenderer>().material.color;

        yield return new WaitForSecondsRealtime(RandomTimeBeforeColorChange3());


    }

    private int RandomTimeBeforeColorChange()
    {
        randomValue = Random.Range(2, 5);
        return randomValue;

    }

    private int RandomTimeBeforeColorChange2()
    {
        randomValue = Random.Range(2, 7);
        return randomValue;

    }

    private int RandomTimeBeforeColorChange3()
    {
        randomValue = Random.Range(2, 7);
        return randomValue;

    }

    private string RandomColorIndex()
    {


        List<string> names1 = new List<string>();
        names1.Add("Blue");
        names1.Add("Red");
        names1.Add("Green");


        if (blueSnitch == null)
        {           
            names1.Remove("Blue");
            return names1[Random.Range(0, names1.Count)];
        }

        if (greenSnitch == null)
        {
            names1.Remove("Green");
            return names1[Random.Range(0, names1.Count)];        
        }

        if (redSnitch == null)
        {
            names1.Remove("Red");
            return names1[Random.Range(0, names1.Count)];
        }

        return names1[Random.Range(0, names1.Count)];
    }

    private string RandomColorIndex2()
    {


        List<string> names2 = new List<string>();
        names2.Add("Blue");
        names2.Add("Red");
        names2.Add("Green");


        if (blueSnitch == null)
        {
            names2.Remove("Blue");
            return names2[Random.Range(0, names2.Count)];
        }

        if (greenSnitch == null)
        {
            names2.Remove("Green");
            return names2[Random.Range(0, names2.Count)];
        }

        if (redSnitch == null)
        {
            names2.Remove("Red");
            return names2[Random.Range(0, names2.Count)];
        }

        return names2[Random.Range(0, names2.Count)];
    }

    private string RandomColorIndex3()
    {
        List<string> names3 = new List<string>();
        names3.Add("Blue");
        names3.Add("Red");
        names3.Add("Green");


        if (blueSnitch == null)
        {
            names3.Remove("Blue");
            return names3[Random.Range(0, names3.Count)];
        }

        if (greenSnitch == null)
        {
            names3.Remove("Green");
            return names3[Random.Range(0, names3.Count)];
        }

        if (redSnitch == null)
        {
            names3.Remove("Red");
            return names3[Random.Range(0, names3.Count)];
        }

        return names3[Random.Range(0, names3.Count)];

    }
}
