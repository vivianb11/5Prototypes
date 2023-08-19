using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack
{
    public abstract void Aim();
    public abstract void CastAttack();
}

public abstract class Movement
{
    public virtual bool SearchEnemy(Transform enemyPos, Transform target, float maxRange, float minRange) {

        float distance = Vector2.Distance(target.position, enemyPos.position);

        if (distance >= maxRange || distance <= minRange)
        {
            return false;
        }

        return true;
    }
    public abstract void Move(Transform target, float moveSpeed);
}
