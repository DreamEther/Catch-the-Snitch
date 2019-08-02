using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    RandomizeNumber randomNum;
    SceneLoader sceneLoader;
    GameSession gameSession;
    PhaseText phaseText;

    int resetBankedTime = 0;
    int currentSceneIndex;
    int snitches;
    int incrementSnitchCounter = 0;
    float bankedTimeAsNum;
    public TextMeshProUGUI bankedTime;
    public TextMeshProUGUI phaseCompleteText;
    public TextMeshProUGUI timerToDisplay;
    public static float startTimer = 20; // to display time left in UI.
    [SerializeField] bool keepTiming = true;
    [SerializeField] bool addToBank = true;

 

    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        startTimer = 20;
        addToBank = true;
        gameSession = FindObjectOfType<GameSession>();
        bankedTime.text = gameSession.GetTimeToAdd().ToString();
        phaseText = FindObjectOfType<PhaseText>();
        sceneLoader = FindObjectOfType<SceneLoader>();

    }

    // Update is called once per frame
    void Update()
    {
        if (currentSceneIndex == 1)
        {
            bankedTime.text = resetBankedTime.ToString();
        }
        snitches = FindObjectsOfType<Snitch>().Length;
        bankedTimeAsNum = float.Parse(bankedTime.text);

        float timeSinceLevelLoad = Time.timeSinceLevelLoad;
        if (timeSinceLevelLoad < 3f)
        {
            phaseText.OnSceneLoad();
        }

        if (keepTiming)
        {
            if (snitches >= 0)
            {
                CountDown();
            }
        }
        AddToBank();
        AddBankedTimeBackToStart();
        LoadGameOver();
    }

    private void AddTimeToBank()
    {
        float roundedCooldown = Mathf.Round(startTimer);
        gameSession.TimeToAdd(roundedCooldown);
        bankedTime.text = gameSession.GetTimeToAdd().ToString();
        addToBank = false;
    }

    private void AddBankedTimeBackToStart()
        {
         if (startTimer <= 0 && bankedTimeAsNum >= 1)
         {
            startTimer = 0;
            StopTimer();
            startTimer += bankedTimeAsNum;
            bankedTime.text = gameSession.ResetBank().ToString();
            keepTiming = true;
         }
    }

    private void LoadGameOver()
    {
        if (startTimer <= 0 && bankedTimeAsNum <= 0)
        {
            startTimer = 0;
            StopTimer();
            sceneLoader.LoadGameOver();
        }
    }

    private void AddToBank()
    {
        if (snitches <= 0 && addToBank == true)
        {
            StopTimer();
            StartCoroutine(TransToSolidColor(true));
            AddTimeToBank();
            StartCoroutine(LoadBufferBetweenScenes());
        }
    }

    public IEnumerator LoadBufferBetweenScenes()
    {
        yield return new WaitForSeconds(3);
        sceneLoader.LoadNextScene();

    }

    private void CountDown()
    {
        startTimer -= Time.deltaTime;
        float roundedCooldown = Mathf.Round(startTimer);
        timerToDisplay.text = roundedCooldown.ToString();
    }

    public void StopTimer()
    {
        keepTiming = false;
    }

    public float GetTime()
    {
        return startTimer;
    }

    public void AddToScore(int increaseSnitchCounter)
    {
        incrementSnitchCounter += increaseSnitchCounter;
    }

    public int GetScore()
    {
        return incrementSnitchCounter;
    }

    IEnumerator TransToSolidColor(bool appear)
    {
        // fade from opaque to transparent
        if (appear)
        {
            // loop over 1 second backwards
            for (float i = 5; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                phaseCompleteText.color = new Color(0, 0.4760594f, 1, i);
                yield return null;
            }

        }


    }
}
