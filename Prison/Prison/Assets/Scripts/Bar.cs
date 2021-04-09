using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    public Slider slider;

    public void SetSlider(float num)
    {
        slider.value = num;
    }

    public void SetMaxSlider(float num)
    {
        slider.maxValue = num;
        slider.value = num;
    }
}
