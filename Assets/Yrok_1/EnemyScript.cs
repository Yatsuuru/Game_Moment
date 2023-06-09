using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private WeaponScript[] weapons;

    void Awake()
    {
        weapons = GetComponentsInChildren<WeaponScript>();
    }

    void Update()
    {
        foreach (WeaponScript weapon in weapons)
        {
            if(weapon != null && weapon.CanAttack)
            {
                weapon.Attack(true);
            }
        }

    }
}
