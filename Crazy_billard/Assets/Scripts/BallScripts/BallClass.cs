using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BallClass
{
    public abstract void BallMovement(int AbilityNumber);
    public virtual void BallAbility()
    {

    }
    public abstract void BallVFX(int number);

    public abstract void ChangeVariable(bool state);
}
