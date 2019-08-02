using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BankedTimeDisplay : MonoBehaviour
{
    TextMeshProUGUI bankedTime;
    GameSession timeToAdd;


    // Start is called before the first frame update
    void Start()
    {
        bankedTime = GetComponent<TextMeshProUGUI>();
        timeToAdd = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        int bankedTimeAsNum = int.Parse(bankedTime.text);
        bankedTime.text += timeToAdd.GetTimeToAdd().ToString();
    }
}
