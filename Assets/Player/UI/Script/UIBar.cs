using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIBar : FindObject
{
    [SerializeField] public Slider[] h_Slider;
    protected static UIBar instance;
    [SerializeField] protected GameObject h_UiPlayer;
    public static UIBar Instance { get => instance; }


    private void Update()
    {
        FindPlayer();
    }

    protected void FindPlayer()
    {
        GameObject gameObject = base.FindObjectWithTag("Player01Animation");
        if (gameObject != null)
        {
            h_UiPlayer.SetActive(true);
        }else { return; }
    }
    public void SetMaxHealth(int maxhealth)
    {
        h_Slider[0].maxValue = maxhealth;
        h_Slider[0].value = maxhealth;
    }
    public void SetHealth(float health)
    {
        h_Slider[0].value = health;
    }


    public void SetMaxEnergy(int maxhealth)
    {
        h_Slider[2].maxValue = maxhealth;
        h_Slider[2].value = maxhealth;
    }
    public void SetEnergy(int health)
    {
        h_Slider[2].value = health;
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
