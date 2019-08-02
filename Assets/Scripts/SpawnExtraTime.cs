using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnExtraTime : MonoBehaviour
{
    [SerializeField] public GameObject extraTimeSprite;
    public bool looping = false;
    public Vector3 minBounds;
    public Vector3 maxBounds;


    // Start is called before the first frame update
    IEnumerator Start()
    {

        yield return new WaitForSecondsRealtime(3);
        do
        {
           yield return StartCoroutine(SpawnExtraTimeIcons());
        }
        while(looping);
     
    } 

    // Update is called once per frame
    void Update()
    {
            
        
    }
    

    IEnumerator SpawnExtraTimeIcons()
    {
       

        float randomTime = Random.Range(0f, 3f);
        float roundedTime = Mathf.Round(randomTime);

        GameObject extraTimeClone = Instantiate(extraTimeSprite, new Vector2(Random.Range(-26.8f, 20.67f), Random.Range(-9.87f, 32.17f)), Quaternion.identity) as GameObject;
        yield return new WaitForSecondsRealtime(randomTime);
        Destroy(extraTimeClone, roundedTime);

        GameObject extraTimeClone1 = Instantiate(extraTimeSprite, new Vector2(Random.Range(-26.8f, 20.67f), Random.Range(-9.87f, 32.17f)), Quaternion.identity) as GameObject;
        yield return new WaitForSecondsRealtime(randomTime);
        Destroy(extraTimeClone1, roundedTime);

        GameObject extraTimeClone2 = Instantiate(extraTimeSprite, new Vector2(Random.Range(-26.8f, 20.67f), Random.Range(-9.87f, 32.17f)), Quaternion.identity) as GameObject;
        yield return new WaitForSecondsRealtime(randomTime);
        Destroy(extraTimeClone2, roundedTime);
   
        
    }
}







