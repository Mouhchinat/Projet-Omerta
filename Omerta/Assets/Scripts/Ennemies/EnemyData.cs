using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "My Game/Enemy Data")]
public class EnemyData : ScriptableObject
{
    public string name;
    public int health;
    public int damage;
    public float speed;
    public float sightRange;
    public float attackRange;

    public void Attack(Player player)
    {
        throw new NotImplementedException();
    }
}
