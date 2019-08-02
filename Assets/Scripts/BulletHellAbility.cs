using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities - Bullet Hell Ability")]
public class BulletHellAbility : Ability
{
    public float projectileFiringPeriod = 0.1f;

    private BulletHellTrigger bulletHell;

    public override void Initialize(GameObject obj)
    {
        bulletHell = obj.GetComponent<BulletHellTrigger>();
        bulletHell.projectileFiringPeriod = projectileFiringPeriod;

    }

    public override void TriggerAbility()
    {
        bulletHell.FireExtraContinuosly();
    }
}
