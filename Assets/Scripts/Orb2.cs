using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Orb2 : MonoBehaviour
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
       
        do
        {
            InvokeRepeating("RandomTimeBeforeColorChange", 0, 0);
            InvokeRepeating("RandomTimeBeforeColorChange2", 0, 0);
            InvokeRepeating("RandomColorIndex", 0, 0);
            InvokeRepeating("RandomColorIndex2", 0, 0);
            yield return StartCoroutine(ChangeColor()); // need the yield return or else unity will crash with the while loop.
        }
        while (looping);
    }

    private void Update()
    {
        blueSnitch = GameObject.FindGameObjectWithTag("blue snitch");
        redSnitch = GameObject.FindGameObjectWithTag("red snitch");
    }

    IEnumerator ChangeColor()
    {

        GetComponent<SpriteRenderer>().material.color = selectColor.GetColor(RandomColorIndex()); // we can use this method because it returns a string, and 'GetColor' requires a string field. 
        GetComponentInChildren<Image>().color = GetComponent<SpriteRenderer>().material.color; // if you use material.color it changes every object with a material to green for some reason.     

        yield return new WaitForSecondsRealtime(RandomTimeBeforeColorChange());

        GetComponent<SpriteRenderer>().material.color = selectColor.GetColor(RandomColorIndex2()); // blue
        GetComponentInChildren<Image>().color = GetComponent<SpriteRenderer>().material.color;

        yield return new WaitForSecondsRealtime(RandomTimeBeforeColorChange2());
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

    private string RandomColorIndex()
    {

        List<string> names1 = new List<string>();
        names1.Add("Blue");
        names1.Add("Red");

        if (blueSnitch == null)
        {
            names1.Remove("Blue");
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
        List<string> names1 = new List<string>();
        names1.Add("Blue");
        names1.Add("Red");

        if (blueSnitch == null)
        {
            names1.Remove("Blue");
            return names1[Random.Range(0, names1.Count)];
        }

        if (redSnitch == null)
        {
            names1.Remove("Red");
            return names1[Random.Range(0, names1.Count)];
        }

        return names1[Random.Range(0, names1.Count)];
    }

}
