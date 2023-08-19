using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GetData : MonoBehaviour
{
    //public GameObject playableInstance;

    //public GameObject particleRecever;

    public List<DataToGive> dataToGive;

    //public GameObject GivePlayableEnemy()
    //{
    //    return playableInstance;
    //}

    //public GameObject GiveParticleRecever()
    //{
    //    return particleRecever;
    //}
}

[Serializable]
public class DataToGive
{
    public string Title;

    public GameObject goData;
    public MonoBehaviour scriptData;


    public DataToGive(GameObject gameObject)
    {
        Title = gameObject.name;
        goData = gameObject;
    }

    public DataToGive(MonoBehaviour script)
    {
        Title = script.name;
        scriptData = script;
    }

    public GameObject GetGoData()
    {
        return goData;
    }
    public MonoBehaviour GetScriptData()
    {
        return scriptData;
    }
}
