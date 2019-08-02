using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Orb4 : MonoBehaviour
{
    private int randomValue;
    public Colors selectColor;
    bool looping = true;
    GameObject redSnitch;
    GameObject blueSnitch;
    GameObject greenSnitch;
    GameObject pinkSnitch;
    GameObject[] orbLightning;
    SpriteRenderer[] orbLightnings;

    private void Awake()
    {
        //var randomizeTimeBetweenColorChange = Random.Range(1, 3);
        // InvokeRepeating("ChangeColor", 0, randomizeTimeBetweenColorChange);
    }
    // Start is called before the first frame update
    IEnumerator Start()
    {

        orbLightning = GameObject.FindGameObjectsWithTag("orb lightning");


        // orbImage = FindObjectOfType<OrbUI>();
        do
        {
            InvokeRepeating("RandomTimeBeforeColorChange", 0, 0);
            InvokeRepeating("RandomTimeBeforeColorChange2", 0, 0);
            InvokeRepeating("RandomTimeBeforeColorChange3", 0, 0);
            InvokeRepeating("RandomTimeBeforeColorChange4", 0, 0);
            InvokeRepeating("RandomColorIndex", 0, 0);
            InvokeRepeating("RandomColorIndex2", 0, 0);
            InvokeRepeating("RandomColorIndex3", 0, 0);
            InvokeRepeating("RandomColorIndex4", 0, 0);
         
            yield return StartCoroutine(ChangeColor()); // need the yield return or else unity will crash with the while loop.
        }
        while (looping);
    }

    private void Update()
    {
        blueSnitch = GameObject.FindGameObjectWithTag("blue snitch");
        redSnitch = GameObject.FindGameObjectWithTag("red snitch");
        greenSnitch = GameObject.FindGameObjectWithTag("green snitch");
        pinkSnitch = GameObject.FindGameObjectWithTag("pink snitch");
    }


    IEnumerator ChangeColor()
    {

        GetComponent<SpriteRenderer>().material.color = selectColor.GetColor(RandomColorIndex()); // we can use this method because it returns a string, and 'GetColor' requires a string field. 
        GetComponentInChildren<Image>().color = GetComponent<SpriteRenderer>().material.color; // if you use material.color it changes every object with a material to green for some reason.
        for (int i = 0; i < orbLightning.Length; i++)
        {
            var orbLightningColor = orbLightning[i].GetComponent<SpriteRenderer>();
            orbLightningColor.material.color = GetComponent<SpriteRenderer>().material.color;
        }

        yield return new WaitForSecondsRealtime(RandomTimeBeforeColorChange());

        GetComponent<SpriteRenderer>().material.color = selectColor.GetColor(RandomColorIndex2()); // blue
        GetComponentInChildren<Image>().color = GetComponent<SpriteRenderer>().material.color;
        for (int i = 0; i < orbLightning.Length; i++)
        {
            var orbLightningColor = orbLightning[i].GetComponent<SpriteRenderer>();
            orbLightningColor.material.color = GetComponent<SpriteRenderer>().material.color;
        }


        yield return new WaitForSecondsRealtime(RandomTimeBeforeColorChange2());


        GetComponent<SpriteRenderer>().material.color = selectColor.GetColor(RandomColorIndex3());
        GetComponentInChildren<Image>().color = GetComponent<SpriteRenderer>().material.color;
        for (int i = 0; i < orbLightning.Length; i++)
        {
            var orbLightningColor = orbLightning[i].GetComponent<SpriteRenderer>();
            orbLightningColor.material.color = GetComponent<SpriteRenderer>().material.color;
        }

        yield return new WaitForSecondsRealtime(RandomTimeBeforeColorChange3());


        GetComponent<SpriteRenderer>().material.color = selectColor.GetColor(RandomColorIndex4());
        GetComponentInChildren<Image>().color = GetComponent<SpriteRenderer>().material.color;
        for (int i = 0; i < orbLightning.Length; i++)
        {
            var orbLightningColor = orbLightning[i].GetComponent<SpriteRenderer>();
            orbLightningColor.material.color = GetComponent<SpriteRenderer>().material.color;
        }

        yield return new WaitForSecondsRealtime(RandomTimeBeforeColorChange4());

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


    private int RandomTimeBeforeColorChange4()
    {
        randomValue = Random.Range(1, 4);
        return randomValue;

    }

    private string RandomColorIndex()
    {
        List<string> names = new List<string>();
        names.Add("Blue");
        names.Add("Red");
        names.Add("Green");
        names.Add("Pink");

        if (blueSnitch == null)
        {
            names.Remove("Blue");
            return names[Random.Range(0, names.Count)];
        }

        if (greenSnitch == null)
        {
            names.Remove("Green");
            return names[Random.Range(0, names.Count)];
        }

        if (redSnitch == null)
        {
            names.Remove("Red");
            return names[Random.Range(0, names.Count)];
        }
        if (pinkSnitch == null)
        {
            names.Remove("Pink");
            return names[Random.Range(0, names.Count)];
        }

        return names[Random.Range(0, names.Count)];
    }

    private string RandomColorIndex2()
    {


        List<string> names = new List<string>();
        names.Add("Blue");
        names.Add("Red");
        names.Add("Green");
        names.Add("Pink");

        if (blueSnitch == null)
        {
            names.Remove("Blue");
            return names[Random.Range(0, names.Count)];
        }

        if (greenSnitch == null)
        {
            names.Remove("Green");
            return names[Random.Range(0, names.Count)];
        }

        if (redSnitch == null)
        {
            names.Remove("Red");
            return names[Random.Range(0, names.Count)];
        }
        if (pinkSnitch == null)
        {
            names.Remove("Pink");
            return names[Random.Range(0, names.Count)];
        }

        return names[Random.Range(0, names.Count)];
    }

    private string RandomColorIndex3()
    {

        List<string> names = new List<string>();
        names.Add("Blue");
        names.Add("Red");
        names.Add("Green");
        names.Add("Pink");

        if (blueSnitch == null)
        {
            names.Remove("Blue");
            return names[Random.Range(0, names.Count)];
        }

        if (greenSnitch == null)
        {
            names.Remove("Green");
            return names[Random.Range(0, names.Count)];
        }

        if (redSnitch == null)
        {
            names.Remove("Red");
            return names[Random.Range(0, names.Count)];
        }
        if (pinkSnitch == null)
        {
            names.Remove("Pink");
            return names[Random.Range(0, names.Count)];
        }

        return names[Random.Range(0, names.Count)];
    }

    private string RandomColorIndex4()
    {


        List<string> names = new List<string>();
        names.Add("Blue");
        names.Add("Red");
        names.Add("Green");
        names.Add("Pink");

        if (blueSnitch == null)
        {
            names.Remove("Blue");
            return names[Random.Range(0, names.Count)];
        }

        if (greenSnitch == null)
        {
            names.Remove("Green");
            return names[Random.Range(0, names.Count)];
        }

        if (redSnitch == null)
        {
            names.Remove("Red");
            return names[Random.Range(0, names.Count)];
        }
        if (pinkSnitch == null)
        {
            names.Remove("Pink");
            return names[Random.Range(0, names.Count)];
        }

        return names[Random.Range(0, names.Count)];
    }

}
