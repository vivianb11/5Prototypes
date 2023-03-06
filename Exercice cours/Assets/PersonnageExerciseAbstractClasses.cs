using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonnageExerciseAbstractClasses : MonoBehaviour
{
    
}

public abstract class Personnage
{

    public abstract void Attaquer(int degats);

    public virtual void Marcher()
    {

    }
    public void Defendre()
    {

    }
}

public class Guerrier : Personnage
{
    public override void Attaquer(int degats)
    {
        throw new System.NotImplementedException();
    }
}

public class Mage : Personnage
{
    public override void Attaquer(int degats)
    {
        throw new System.NotImplementedException();
    }
}

public class Archer : Personnage
{
    public override void Attaquer(int degats)
    {
        throw new System.NotImplementedException();
    }
}