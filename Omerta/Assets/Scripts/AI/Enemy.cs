using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapon;

[CreateAssetMenu(fileName = "EnemyData", menuName = "My Game/Enemy Data")]
public class Enemy : ScriptableObject
{
    public string name;
    public int health;
    public float speed;
    public float sightRange;
    public bool isAlive;
    public RangeWeapon rangeWeapon;
    public int ammo;

    public void Attack(Player player)
    {
        if (player.isAlive)
        {
            int HowMany = 0;
            if (rangeWeapon.Shot())
            {
                player.health -= rangeWeapon.Damage;
            }
            else
            {
                if (ammo > 0)
                {
                    HowMany = (ammo > rangeWeapon.Capacity ? rangeWeapon.Capacity : ammo);
                    ammo -= HowMany;
                    rangeWeapon.Reload(HowMany);
                }
            }
        }
    }
}
