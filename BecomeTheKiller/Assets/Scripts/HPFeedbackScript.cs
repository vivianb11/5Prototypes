using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPFeedbackScript : MonoBehaviour
{
    public Image fillColor;
    public Slider hpSlider;

    // Update is called once per frame
    void Update()
    {
        if (hpSlider.value < hpSlider.maxValue/4)
        {
            fillColor.color = Color.red;
        }
        else
        {
            fillColor.color = Color.green;
        }
    }
}
