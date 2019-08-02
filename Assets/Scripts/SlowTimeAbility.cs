using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities - Slow Time Ability")]
public class SlowTimeAbility : Ability
{

    public float timeScale = 0.5f;
    public float slowTimeCooldown;
    bool slowTimeReady = true;
    private SlowTimeAbilityTrigger slowTime;

    public override void Initialize(GameObject obj)
    {
        slowTime = obj.GetComponent<SlowTimeAbilityTrigger>();
        slowTime.timeScale = timeScale;
        slowTime.slowTimeCooldown = slowTimeCooldown;
        slowTime.slowTimeReady = slowTimeReady;

    }

    public override void TriggerAbility()
    {
        slowTime.SlowTime();
    }


    
}
