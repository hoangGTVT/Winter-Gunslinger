using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerManager : FindObject
{

    public PlayerLife playerLife;
    public Waepon waepon;
    public TextMeshProUGUI[] textMeshProUGUI;
    public TextMeshProUGUI[] textMeshProUGUI1;
    [SerializeField] protected GameObject h_PlayerPrefab;
    void Update()
    {
        FindPlayer();
        FindWeapon();
        if (Input.GetKeyDown(KeyCode.H))
        {
            GameObject game= Instantiate(h_PlayerPrefab,new Vector3(0,0,0), Quaternion.identity);
        }

    }
    public void Create()
    {
        AudioManager.instance.Play("Button");
        GameObject game = Instantiate(h_PlayerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }

    protected void FindWeapon()
    {
        GameObject gameObject = base.FindObjectWithTag("BulletPLayer");
        if (gameObject != null)
        {
            waepon=gameObject.GetComponent<Waepon>();
        }
        else
        {
            waepon = null;
        }
    }
    protected void FindPlayer()
    {
        GameObject gameObject = base.FindObjectWithTag("Player01Animation");
        if (gameObject != null)
        {
            playerLife = gameObject.GetComponent<PlayerLife>();
            ShowText();
            ShowText1();
        }
        else
        {
            playerLife = null;
        }
        
    }

    protected void ShowText()
    {
        textMeshProUGUI[0].text = "" + playerLife.GetEnergy();
        textMeshProUGUI[1].text = "/" + playerLife.GetTotalHP();
        textMeshProUGUI[2].text = "" + playerLife.GetCurrentHP();
        textMeshProUGUI[3].text = "LV:" + playerLife.GetLevel();
        textMeshProUGUI[4].text = "" + playerLife.GetEXP();
        textMeshProUGUI[5].text = "/" + playerLife.GetMaxEXP();
        textMeshProUGUI[6].text = "/" + playerLife.GetTotalE();
        textMeshProUGUI[7].text = "" + playerLife.GetTotalATK();
        textMeshProUGUI[8].text = "" + playerLife.GetTotalDEF();
        textMeshProUGUI[9].text = "" + playerLife.GetGold();
        textMeshProUGUI[10].text=""+playerLife.GetHPPoint();
        textMeshProUGUI[11].text=""+ playerLife.GetMPPoint();
    }

    protected void ShowText1()
    {
        textMeshProUGUI1[0].text = "" + playerLife.GetGoldATK();
        textMeshProUGUI1[1].text = "LV:" + playerLife.GetLvATK();
        textMeshProUGUI1[2].text = "" + playerLife.GetGoldE();
        textMeshProUGUI1[3].text = "LV:" + playerLife.GetLvE();
        textMeshProUGUI1[4].text = "" + playerLife.GetGoldHP();
        textMeshProUGUI1[5].text = "LV:" + playerLife.GetLvHP();
        textMeshProUGUI1[6].text = "" + playerLife.GetGoldDEF();
        textMeshProUGUI1[7].text = "LV:" + playerLife.GetLvDEF();
        textMeshProUGUI1[8].text = "LV:" + playerLife.GetLevel();
        textMeshProUGUI1[9].text = "" + playerLife.GetGold();
        textMeshProUGUI1[10].text = "" + playerLife.GetTotalHP();
        textMeshProUGUI1[11].text = "" + playerLife.GetTotalE();
        textMeshProUGUI1[12].text = "" + playerLife.GetTotalDEF();
        textMeshProUGUI1[13].text = "" + playerLife.GetTotalATK();

    }

    public void HpPoint()
    {
        if (playerLife != null)
        {
            AudioManager.instance.Play("Button");
            playerLife.HealHP();
        }
        else
        {
            AudioManager.instance.Play("Button");
            return;
        }
    }
    public void MpPoint()
    {
        if (playerLife != null)
        {
            AudioManager.instance.Play("Button");
            playerLife.HealEnergy();
        }
        else
        {
            AudioManager.instance.Play("Button");
            return;
        }
    }

    public void UpLVHP()
    {
        if (playerLife != null)
        {
            AudioManager.instance.Play("Button");
            playerLife.UpLvHP();
        }
        else
        {
            AudioManager.instance.Play("Button");
            return;
        }
       
    }
    public void UpLVE()
    {
        if (playerLife != null)
        {
            AudioManager.instance.Play("Button");
            playerLife.UpLvE();
        }
        else
        {
            AudioManager.instance.Play("Button");
            return;
        }

    }

    public void UpLVATK()
    {
        if (playerLife != null)
        {
            AudioManager.instance.Play("Button");
            playerLife.UpLvATK();
        }
        else
        {
            AudioManager.instance.Play("Button");
            return;
        }

    }
    public void UpLVDEF()
    {
        if (playerLife != null)
        {
            AudioManager.instance.Play("Button");
            playerLife.UpLvDEF();
        }
        else
        {
            AudioManager.instance.Play("Button");
            return;
        }

    }

    //choose bullet

    public void Bullet1()
    {
        if (waepon != null)
        {
            waepon.SetBullet(0);
        }
        else
        {
            return;
        }
    }
    public void Bullet2()
    {
        if (waepon != null)
        {
            waepon.SetBullet(1);
        }
        else
        {
            return;
        }
    }

    public void Bullet3()
    {
        if (waepon != null)
        {
            waepon.SetBullet(2);
        }
        else
        {
            return;
        }
    }

    public void Bullet4()
    {
        if (waepon != null)
        {
            waepon.SetBullet(3);
        }
        else
        {
            return;
        }
    }

    public void Bullet5()
    {
        if (waepon != null)
        {
            waepon.SetBullet(4);
        }
        else
        {
            return;
        }
    }
}
