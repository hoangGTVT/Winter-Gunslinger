using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : FindObject
{

    public PlayerLife playerLife;
    public Waepon waepon;
    public GameObject game;
    public TextMeshProUGUI[] textMeshProUGUI;
    public TextMeshProUGUI[] textMeshProUGUI1;
    public TextMeshProUGUI[] namePlayer;
    [SerializeField] protected GameObject h_PlayerPrefab;
    [SerializeField] protected GameObject[] h_updragePlayer;
    [SerializeField] protected GameObject h_PLayerDead;

    
    void Update()
    {
        FindPlayer();
        FindWeapon();

        



    }

   
    public void Create()
    {
        AudioManager.instance.Play("Button");
        if (PlayerPrefs.GetFloat("Gold") > 300)
        {
            float b = PlayerPrefs.GetFloat("Gold");
            b -= 300;
            PlayerPrefs.SetFloat("Gold", b);
            int c = PlayerPrefs.GetInt("Map");
            switch(c)
            {
                case 0:
                    GameObject game = Instantiate(h_PlayerPrefab, new Vector3(-13, -6, 0), Quaternion.identity);
                    break;
                case 1:
                    GameObject game1 = Instantiate(h_PlayerPrefab, new Vector3(11, -7, 0), Quaternion.identity);
                    break;
                case 2:
                    GameObject game2 = Instantiate(h_PlayerPrefab, new Vector3(-12, 0, 0), Quaternion.identity);
                    break;
                case 3:
                    GameObject game3 = Instantiate(h_PlayerPrefab, new Vector3(17, 1, 0), Quaternion.identity);
                    break;
                case 4:
                    GameObject game4 = Instantiate(h_PlayerPrefab, new Vector3(-10, -1.1f, 0), Quaternion.identity);
                    break;
                case 5:
                    GameObject game5 = Instantiate(h_PlayerPrefab, new Vector3(-5, -6, 0), Quaternion.identity);
                    break;


            }

            
           
        }
        else
        {
            h_PLayerDead.SetActive(true);
        }


    }

    public void Home()
    {
        SceneManager.LoadScene("StartGame");
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

    public void OnButtonPlayer()
    {
        GameObject gameObject = base.FindObjectWithTag("Player01Animation");
        if (gameObject != null)
        {
            playerLife = gameObject.GetComponent<PlayerLife>();
            AudioManager.instance.Play("Button");
            h_updragePlayer[0].SetActive(true);
        }
        else
        {
            playerLife = null;
        }
    }
    public void OnButtonPlayer1()
    {
        GameObject gameObject = base.FindObjectWithTag("Player01Animation");
        if (gameObject != null)
        {
            playerLife = gameObject.GetComponent<PlayerLife>();
            AudioManager.instance.Play("Button");
            h_updragePlayer[1].SetActive(true);
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
        textMeshProUGUI[12].text = "" + PlayerPrefs.GetInt("Key"); ;
        namePlayer[0].text = "" + PlayerPrefs.GetString("NamePlayer");
        namePlayer[1].text = "" + PlayerPrefs.GetString("NamePlayer");
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

    public void BuyHpPoint()
    {
        if (playerLife != null)
        {
            AudioManager.instance.Play("Button");
            if (playerLife.GetGold() >= 200)
            {
                playerLife.DecreaseGold(200);
                playerLife.PlusHPPoint();
                h_updragePlayer[3].SetActive(true);
            }
            else
            {
                h_updragePlayer[2].SetActive(true);
            }
            
        }
    }

    public void BuyMpPoint()
    {
        if (playerLife != null)
        {
            AudioManager.instance.Play("Button");
            if (playerLife.GetGold() >= 200)
            {
                playerLife.DecreaseGold(200);
                playerLife.PlusMPPoint();
                h_updragePlayer[3].SetActive(true);
            }
            else
            {
                h_updragePlayer[2].SetActive(true);
            }

        }
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
            game.SetActive(true);
        }
        else
        {
            return;
        }
    }
    public void Bullet2()
    {
        if (waepon != null  )
        {
            if(PlayerPrefs.GetFloat("ChooseBullet") > 0)
            {
                waepon.SetBullet(1);
                game.SetActive(true);
            }
            else
            {
                h_updragePlayer[4].SetActive(true);
            }
           
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
            if (PlayerPrefs.GetFloat("ChooseBullet") > 1)
            {
                waepon.SetBullet(2);
                game.SetActive(true);
            }
            else
            {
                h_updragePlayer[4].SetActive(true);
            }
        }
        else
        {
            return;
        }
    }

    
}
