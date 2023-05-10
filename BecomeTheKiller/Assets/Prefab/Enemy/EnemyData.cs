using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObject/EnemyData")]
public class EnemyData : ScriptableObject
{
    public enum TypeOfAttaque {melee, distance};
    public TypeOfAttaque typeOfAttaque;

    [Range(1,20)]
    public int attackDamage;
    public int attackSpeed;
    public int attackRange;

    [Range(1, 5)]
    public float playerSpeed;

    [Range(1, 100)]
    public int hp;

    [Range(1, 6)]
    public float detectionZone;

}
