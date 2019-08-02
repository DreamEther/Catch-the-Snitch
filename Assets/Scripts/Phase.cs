using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase : MonoBehaviour
{
    GameObject[] snitches;
    SceneLoader sceneLoader;

    // Start is called before the first frame update
    void Start()
    {
        snitches = GameObject.FindGameObjectsWithTag("snitch");
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SnitchDestroyed()
    {
       
    }
}
