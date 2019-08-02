using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class RandomizeNumber : MonoBehaviour
{
    //GameTimer gameTimer;
    [SerializeField] AudioClip extraTimePickupSound;
    [SerializeField] [Range(0, 1)] float extraTimePickupSoundVolume = 0.25f;
    TextMeshPro extraTime;
    bool addTime = false;
    Player player;
    public bool addExtraTime = false;
    public float roundedNumber;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        //gameTimer = FindObjectOfType<GameTimer>(); // DONT FORGET TO INITIALIZE...OTHERWISE WHEN WE REFERENCE GAMETIMER NOTHING WILL HAPPEN!!!!! THIS IS WHY TIME WOULDN'T ADD TO GAMETIMER CLASS WHICH CONTAINS STARTTIMER
        RandomNumber();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void RandomNumber()

    {
        float randomNumber = Random.Range(1f, 3f);
        roundedNumber = Mathf.Round(randomNumber);

        extraTime = GetComponentInChildren<TextMeshPro>();
        extraTime.text = roundedNumber.ToString();
    }

   


    private void OnTriggerEnter2D(Collider2D otherGameObject)
    {
        Player player = otherGameObject.gameObject.GetComponent<Player>();

        if (!player)
        {
            addExtraTime = false;
            return;
        }

        ProcessPlayerCollision(player);
        AudioSource.PlayClipAtPoint(extraTimePickupSound, player.transform.position, extraTimePickupSoundVolume);
        float extraTimeAsNumber = float.Parse(extraTime.text);
        GameTimer.startTimer += extraTimeAsNumber; // I changed startTimer to a static field since we have multiple classes accessing its value
        addExtraTime = true;
    }

    public void ProcessPlayerCollision(Player player) 
    {
        Destroy(gameObject);
    }

   
}