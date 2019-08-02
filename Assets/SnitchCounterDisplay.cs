using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SnitchCounterDisplay : MonoBehaviour
{
    TextMeshProUGUI snitchCounterText;
    GameTimer gameTimer;
    // Start is called before the first frame update
    void Start()
    {
        snitchCounterText = GetComponent<TextMeshProUGUI>();
        gameTimer = FindObjectOfType<GameTimer>();
    }

    // Update is called once per frame
    void Update()
    {
        snitchCounterText.text = gameTimer.GetScore().ToString();
    }


}
