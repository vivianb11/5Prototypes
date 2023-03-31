using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject ennemy in enemies)
        {
            ennemy.GetComponent<Behaviour>().SetNewPlayer(this.gameObject);
        }

        GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
        camera.GetComponent<CameraMovement>().target = this.gameObject.transform;
    }
}
