using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BallClass
{
    public abstract IEnumerator BallMovement(float time);
    public abstract void BallAbility();
    public abstract void BallVFX(int number);
}
