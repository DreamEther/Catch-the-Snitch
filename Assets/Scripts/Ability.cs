using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : ScriptableObject
{

    public string aName = "New Ability";
    public Sprite aSprite; // this is the ability icon that will overwrite dark mask at runtime. 
    public AudioClip aSound;
    public float aBaseCoolDown = 10f;

    public abstract void Initialize(GameObject obj);
    public abstract void TriggerAbility(); // every ability is going to need to be triggerable, but their function will be different. 
 
}

