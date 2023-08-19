using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI text;


    // Updates the nuber of balles left
    void Update()
    {
        text.text= "Balles restantes : " + GlobalBalls.ballNumber;
    }
}
