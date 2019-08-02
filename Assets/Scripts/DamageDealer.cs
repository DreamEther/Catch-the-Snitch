using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{

    [SerializeField] int damage = 100;
    [SerializeField] int shipCollisionDamage = 50;


    // Start is called before the first frame update
  
    public int GetWeaponDamage()
    {
        return damage;
    }

    public int GetShipCollisionDamage()
    {
        return shipCollisionDamage;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }
}
