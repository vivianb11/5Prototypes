using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSetup : MonoBehaviour
{
    private void OnEnable()
    {
        GlobalBalls.ballNumber += 1;
    }

    private void OnDisable()
    {
        GlobalBalls.ballNumber -= 1;
    }
}
