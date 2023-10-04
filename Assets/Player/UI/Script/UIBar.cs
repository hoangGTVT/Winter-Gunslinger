using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIBar : FindObject
{
    [SerializeField] public Slider[] h_Slider;
    protected static UIBar instance;
    [SerializeField] protected GameObject[] h_UiPlayer;
    public static UIBar Instance { get => instance; }
    public PlayerLife playerLife;


    private void Update()
    {
        FindPlayer();
    }

    protected void FindPlayer()
    {
        GameObject gameObject = base.FindObjectWithTag("Player01Animation");
      
        if (gameObject != null)
        {
            h_UiPlayer[0].SetActive(true);
            playerLife = gameObject.GetComponent<PlayerLife>();
        }
        else { h_UiPlayer[0].SetActive(false); }

        if (playerLife != null)
        {
            if (playerLife.GetIsDead() == true)
            {
                h_UiPlayer[1].SetActive(true);
            }
            else
            {
                h_UiPlayer[1].SetActive(false);
            }
        }
    }


    public void SetMaxHealth(float maxhealth)
    {
        h_Slider[0].maxValue = maxhealth;
        h_Slider[0].value = maxhealth;
    }
    public void SetHealth(float health)
    {
        h_Slider[0].value = health;
    }


    public void SetMaxEnergy(float maxhealth)
    {
        h_Slider[2].maxValue = maxhealth;
        h_Slider[2].value = maxhealth;
    }
    public void SetEnergy(float health)
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
