using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class AbilityCooldown : MonoBehaviour
{
    public string abilityButtonAxisName = "Slow Time";
    public Image darkMask;
    public Text coolDownTextDisplay;

    [SerializeField] private Ability ability;
    [SerializeField] private GameObject player;

    private Image myButtonImage;
    private AudioSource abilitySource;
    private float coolDownDuration; // going to be set from aBaseCooldown in Ability
    private float nextReadyTime; // next time in seconds when the object is going to come off cooldown
    private float coolDownTimeLeft; // to display time left in UI.

    // Start is called before the first frame update
    void Start()
    {
        Initialize(ability, player);
    }

     public void Initialize(Ability selectedAbility, GameObject player)
    {
        ability = selectedAbility;
        myButtonImage = GetComponent<Image>();
        abilitySource = GetComponent<AudioSource>();
        myButtonImage.sprite = ability.aSprite;
        darkMask.sprite = ability.aSprite;
        coolDownDuration = ability.aBaseCoolDown;
        ability.Initialize(player); // this is where we get the gameObject that our ability is attached
        AbilityReady();
    }

    // Update is called once per frame
    void Update()
    {
        bool coolDownComplete = (Time.time > nextReadyTime); // if more time has elapsed than next ready time, coolDownComplete is going to be true. 
        if (coolDownComplete)
        {
            AbilityReady();
            if (CrossPlatformInputManager.GetButtonDown(abilityButtonAxisName))
            {
                ButtonTriggered();
            }
        }
        else
        {
            CoolDown(); // if cooldown is not complete, we're going to continue calling CoolDown();
        }
    }

    private void AbilityReady() // cooldown text and mask will be turned off when ability is ready to use
    {
        coolDownTextDisplay.enabled = false;
        darkMask.enabled = false;
    }

    private void CoolDown() // called every frame when we're on cooldown
    {
        coolDownTimeLeft -= Time.deltaTime;
        float roundedCooldown = Mathf.Round(coolDownTimeLeft);
        coolDownTextDisplay.text = roundedCooldown.ToString();
        darkMask.fillAmount = (coolDownTimeLeft / coolDownDuration);
    }

    private void ButtonTriggered()
    {
        nextReadyTime = coolDownDuration + Time.time;
        coolDownTimeLeft = coolDownDuration;
        darkMask.enabled = true;
        coolDownTextDisplay.enabled = true;

        abilitySource.clip = ability.aSound;
        abilitySource.Play();
        ability.TriggerAbility(); // this is where we call the function of our ability
        abilitySource.pitch = 0.5f;
    }

    public void OnPointerDown()
    {
        Update();
    }
}
