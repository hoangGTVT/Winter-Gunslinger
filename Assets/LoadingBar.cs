using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingBar : MonoBehaviour
{
    public Slider slider;
    
    public void SetMaxValue(float v)
    {
        slider.maxValue = 100;
        slider.value = v;
       
    }
    public void SetValue(float v)
    {
        slider.value = v;
    }
    
}
