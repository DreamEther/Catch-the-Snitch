using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    [CreateAssetMenu(menuName = "Abilities - Speed Boost Ability")]
    public class SpeedBoostAbility : Ability
    {

    public float addedForce = 1000f;

        private SpeedBoostTrigger speedBoost;

        public override void Initialize(GameObject obj)
        {
            speedBoost = obj.GetComponent<SpeedBoostTrigger>();
            speedBoost.addedForce = addedForce;

        }

        public override void TriggerAbility()
        {
        speedBoost.InitiateSpeedBoost();
        }
    
}
