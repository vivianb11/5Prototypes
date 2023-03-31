using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObject/EnemyData")]
public class EnemyData : ScriptableObject
{
    public enum TypeOfAttaque {melee, distance};
    public TypeOfAttaque typeOfAttaque;

    public int attackDamage;
    public int attackSpeed;
    public int attackRange;
    public float playerSpeed;

    public int hp;

    public float detectionZone;
}
