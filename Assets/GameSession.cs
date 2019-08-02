using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    float timeToAdd = 0;


    void Awake()
    {
        SetUpSingleton();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   

        void SetUpSingleton()
        {
          int numberOfSessions = FindObjectsOfType<GameSession>().Length;
          if (numberOfSessions > 1)
          {
             Destroy(gameObject);
          }

          else
          {
             DontDestroyOnLoad(gameObject);
          }
        }

    public float GetTimeToAdd()
    {
        return timeToAdd;
    }

    public void TimeToAdd(float startTimer)
    {
        timeToAdd += startTimer;

    }

    public float ResetBank()
    {
        return timeToAdd = 0;
    }
}
