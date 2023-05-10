using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ChangeData : MonoBehaviour
{
    public GameObject playableInstance;

    public GameObject particleRecever;

    public List<DataToGive> dataToGive;

    public GameObject GivePlayableEnemy()
    {
        return playableInstance;
    }

    public GameObject GiveParticleRecever()
    {
        return particleRecever;
    }
}

[Serializable]
public class DataToGive
{
    public string Title;

    public GameObject goData;


    public DataToGive(GameObject gameObject)
    {
        goData = gameObject;
        Title = gameObject.name;
    }

    public GameObject GiveData()
    {
        return goData;
    }
}
