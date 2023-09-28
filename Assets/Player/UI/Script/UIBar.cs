using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIBar : MonoBehaviour
{
    [SerializeField] public Slider[] h_Slider;
    protected static UIBar instance; 
    public static UIBar Instance { get => instance; }

    public void SetMaxHealth(int maxhealth)
    {
        h_Slider[0].maxValue = maxhealth;
        h_Slider[0].value = maxhealth;
    }
    public void SetHealth(float health)
    {
        h_Slider[0].value = health;
    }

    

    public void SetMaxEXP(float mp)
    {
        h_Slider[1].maxValue = mp;
        h_Slider[1].value = mp;
    }
    public void SetEXP(float mp)
    {
        h_Slider[1].value = mp;
    }
}
