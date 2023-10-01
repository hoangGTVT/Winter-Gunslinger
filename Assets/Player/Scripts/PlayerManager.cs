using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerManager : FindObject
{

    public PlayerLife playerLife;
    public TextMeshProUGUI[] textMeshProUGUI;
    [SerializeField] protected GameObject h_PlayerPrefab;
    void Update()
    {
        FindPlayer();
        if (Input.GetKeyDown(KeyCode.H))
        {
            GameObject game= Instantiate(h_PlayerPrefab,new Vector3(0,0,0), Quaternion.identity);
        }

    }

    protected void FindPlayer()
    {
        GameObject gameObject = base.FindObjectWithTag("Player01Animation");
        if (gameObject != null)
        {
            playerLife = gameObject.GetComponent<PlayerLife>();
            ShowText();
        }
        else
        {
            playerLife = null;
        }
        
    }

    protected void ShowText()
    {
        textMeshProUGUI[0].text = "" + playerLife.GetEnergy();
        textMeshProUGUI[1].text = "/" + playerLife.GetMaxHP();
        textMeshProUGUI[2].text = "" + playerLife.GetCurrentHP();
        textMeshProUGUI[3].text = "LV:" + playerLife.GetLevel();
        textMeshProUGUI[4].text = "" + playerLife.GetEXP();
        textMeshProUGUI[5].text = "/" + playerLife.GetMaxEXP();
        textMeshProUGUI[6].text = "/" + playerLife.GetMaxEnergy();
        textMeshProUGUI[7].text = "" + playerLife.GetATK();
        textMeshProUGUI[8].text = "" + playerLife.GetDEF();
        textMeshProUGUI[9].text = "" + playerLife.GetGold();
    }
}
