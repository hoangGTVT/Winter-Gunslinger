using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class PlayerLife : FindObject
{
    
    public UIBar bar;
    public GameObject[] h_HpPopUp;
   
    

    [SerializeField] protected int h_HPPoint;
    [SerializeField] protected int h_MPPoint;
    [SerializeField] protected int h_Key=0;

    // HP
    [SerializeField] protected float h_MaxHp;
    [SerializeField] protected float h_CurrentHp;
    [SerializeField] protected float h_BonusHP;
    [SerializeField] protected float h_TotalHP;
    [SerializeField] protected bool h_IsDead=false;
    [SerializeField] protected bool h_IsDizzy=false;
    [SerializeField] protected float h_GoldHP;
    [SerializeField] protected int h_LvHP;

    // ATK
    [SerializeField] protected float h_MaxATK;
    
    [SerializeField] protected float h_BonusATK;
    [SerializeField] protected float h_TotalATK;
    [SerializeField] protected float h_GoldATK;
    [SerializeField] protected int h_LvATK;

    // Energy
    [SerializeField] protected float h_MaxEnergyFly ;
    [SerializeField] protected float h_GoldE;
    [SerializeField] protected float h_TotalE;
    [SerializeField] protected float h_CurrentEnergyFly;
    [SerializeField] protected float h_BonusEnegry;
    [SerializeField] protected int h_LvE;

    // DEF
    [SerializeField] protected float h_MaxDEF;
    [SerializeField] protected float h_BonusDEF;
    [SerializeField] protected float h_TotalDEF;
    [SerializeField] protected float h_GoldDEF;
    [SerializeField] protected int h_LvDEF;

    // EXP
    [SerializeField] protected float h_MaxExp=100;
    [SerializeField] protected float h_CurrentExp;
    [SerializeField] protected float h_CurrentLevel=1;
    [SerializeField] protected bool h_IsLevelUp=false;
    [SerializeField] protected float h_EnergyCooldown = 5f;
    

    //Gold
    [SerializeField] protected float h_Gold;
    private void Awake()
    {

        PlayerPrefs.DeleteAll();
        FindUiBar();
        GetStartValue();
        
    }
    private void Start()
    {
        SetMaxValue();

        StartCoroutine(HealEnegryEveryFiveSecon());
        
    }

    protected void FindUiBar()
    {
        GameObject game = base.FindObjectWithTag("UIPlayer");
        if (game != null)
        {
            bar = game.GetComponent<UIBar>();
        }
        else { return; }
    }
    private void Update()
    {
        FindUiBar();
        if (Input.GetKeyDown(KeyCode.M))
        {


            TakeGold(50);
            

        }
        if (Input.GetKeyDown(KeyCode.N))
        {

            PlusMPPoint();
            
        }

        if (Input.GetKeyDown(KeyCode.B))
        {

           PlayerTakeDamage(50);
        }
        if (Input.GetKeyDown(KeyCode.V))
        {

            PlusHPPoint();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {

            PlayerTakeExp(50);
        }

        SetValue();
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Dead"))
        {
            PlayerDead();
        }
    }

    protected void GetStartValue()
    {
        // Set HP

        if (PlayerPrefs.GetInt("HPPoint") == 0) {
            h_HPPoint = 0;
        }
        else
        {
            h_HPPoint = PlayerPrefs.GetInt("HPPoint");
        }
        if (PlayerPrefs.GetFloat("MaxHPPlayer") < 200)
        {
            h_MaxHp = 200;
            
        }
        else
        {
            h_MaxHp = PlayerPrefs.GetFloat("MaxHPPlayer");
           
        }

        if (PlayerPrefs.GetFloat("BonusHPPlayer") < 1)
        {
            h_BonusHP = 0;
        }
        else
        {
            h_BonusHP = PlayerPrefs.GetFloat("BonusHPPlayer");
        }

        if (PlayerPrefs.GetFloat("GoldHP") < 100)
        {
            h_GoldHP= 100;
            PlayerPrefs.SetFloat("GoldHP", h_GoldHP);
        }
        else
        {
            h_GoldHP = PlayerPrefs.GetFloat("GoldHP");
        }

        if (PlayerPrefs.GetInt("LVHP") < 1)
        {
            h_LvHP = 1;
            PlayerPrefs.SetInt("LVHP", h_LvHP);
        }
        else
        {
            h_LvHP = PlayerPrefs.GetInt("LVHP");
        }

        PlayerPrefs.SetFloat("TotalHP", h_MaxHp + h_BonusHP);
        h_TotalHP= PlayerPrefs.GetFloat("TotalHP");
        h_CurrentHp = h_TotalHP;



        // Set Energy

        if (PlayerPrefs.GetInt("MPPoint") == 0)
        {
            h_MPPoint = 0;
        }
        else
        {
            h_MPPoint = PlayerPrefs.GetInt("MPPoint");
        }

        if (PlayerPrefs.GetFloat("MaxEnergyPlayer") < 100)
        {
            h_MaxEnergyFly = 100;
            
        }
        else
        {
            h_MaxEnergyFly = PlayerPrefs.GetFloat("MaxEnergyPlayer");
            
        }

        if (PlayerPrefs.GetFloat("BonusE") < 1)
        {
            h_BonusEnegry = 0;
        }
        else
        {
            h_BonusEnegry = PlayerPrefs.GetFloat("BonusE");
        }
        if (PlayerPrefs.GetFloat("GoldE") < 100)
        {
            h_GoldE = 100;
            PlayerPrefs.SetFloat("GoldE", h_GoldE);
        }
        else
        {
            h_GoldE = PlayerPrefs.GetFloat("GoldE");
        }
        if (PlayerPrefs.GetInt("LVE") < 1)
        {
            h_LvE = 1;
            PlayerPrefs.SetInt("LVE", h_LvE);
        }
        else
        {
            h_LvE = PlayerPrefs.GetInt("LVE");
        }

        PlayerPrefs.SetFloat("TotalE", h_MaxEnergyFly + h_BonusEnegry);
        h_TotalE = PlayerPrefs.GetFloat("TotalE");
        h_CurrentEnergyFly = h_TotalE;

        //Set Level

        if (PlayerPrefs.GetFloat("LevelPlayer") < 1)
        {
            h_CurrentLevel = 1;
            PlayerPrefs.SetFloat("LevelPlayer", h_CurrentLevel);
        }
        else
        {
            h_CurrentLevel = PlayerPrefs.GetFloat("LevelPlayer");
        }

        //Set EXP
        h_CurrentExp = PlayerPrefs.GetFloat("CurrentEXP");
        if (PlayerPrefs.GetFloat("MaxEXP") < 100)
        {
            h_MaxExp = 100;
            PlayerPrefs.SetFloat("MaxEXP", h_MaxExp);
        }
        else
        {
            h_MaxExp = PlayerPrefs.GetFloat("MaxEXP");
        }

        //Set ATK
        if (PlayerPrefs.GetFloat("ATKPlayer") < 15)
        {
            h_MaxATK = 15;
            PlayerPrefs.SetFloat("ATKPlayer", h_MaxATK);
        }
        else
        {
            h_MaxATK = PlayerPrefs.GetFloat("ATKPlayer");
        }

        if (PlayerPrefs.GetFloat("BonusATK") < 1)
        {
            h_BonusATK = 0;
        }
        else
        {
            h_BonusATK = PlayerPrefs.GetFloat("BonusATK");
        }
        PlayerPrefs.SetFloat("TotalATK", h_MaxATK + h_BonusATK);
        h_TotalATK = PlayerPrefs.GetFloat("TotalATK");
        
        if (PlayerPrefs.GetFloat("GoldATK") < 100)
        {
            h_GoldATK = 100;
            PlayerPrefs.SetFloat("GoldATK", h_GoldATK);
        }
        else
        {
            h_GoldATK = PlayerPrefs.GetFloat("GoldATK");
        }
        PlayerPrefs.SetFloat("TotalATK", h_MaxATK + h_BonusEnegry);
        
       

        if (PlayerPrefs.GetInt("LVATK") < 1)
        {
            h_LvATK = 1;
            PlayerPrefs.SetInt("LVATK", h_LvATK);
        }
        else
        {
            h_LvATK = PlayerPrefs.GetInt("LVATK");
        }


        //Set DEF
        if (PlayerPrefs.GetFloat("DEFPlayer") < 100)
        {
            h_MaxDEF= 100;
            PlayerPrefs.SetFloat("DEFPlayer", h_MaxDEF);
        }
        else
        {
            h_MaxDEF = PlayerPrefs.GetFloat("DEFPlayer");
        }

        if (PlayerPrefs.GetFloat("BonusDEF") < 1)
        {
            h_BonusDEF = 0;
        }
        else
        {
            h_BonusDEF = PlayerPrefs.GetFloat("BonusDEF");
        }

        PlayerPrefs.SetFloat("TotalDEF", h_MaxDEF + h_BonusDEF);
        h_TotalDEF = PlayerPrefs.GetFloat("TotalDEF");
        

        if (PlayerPrefs.GetFloat("GoldDEF") < 100)
        {
            h_GoldDEF = 100;
            PlayerPrefs.SetFloat("GoldDEF", h_GoldDEF);
        }
        else
        {
            h_GoldDEF = PlayerPrefs.GetFloat("GoldDEF");
        }
        if (PlayerPrefs.GetInt("LVDEF") < 1)
        {
            h_LvDEF = 1;
            PlayerPrefs.SetInt("LVDEF", h_LvDEF);
        }
        else
        {
            h_LvDEF = PlayerPrefs.GetInt("LVDEF");
        }

        //Set Gold

        if (PlayerPrefs.GetFloat("Gold") == 0)
        {
            h_Gold = 0;
        }
        else
        {
            h_Gold = PlayerPrefs.GetFloat("Gold");
        }

    }

    public void SetValue()
    {
        bar.SetEnergy(h_CurrentEnergyFly);
        bar.SetEXP(h_CurrentExp);
        bar.SetHealth(h_CurrentHp);
        
    }


    public void SetMaxValue()
    {
        bar.SetMaxEnergy(h_TotalE);
        bar.SetMaxHealth(h_TotalHP);
        bar.SetMaxEXP(h_MaxExp);
    }

    // Set/Get Energy
    public float GetEnergy()
    {
        
        return h_CurrentEnergyFly;
    }

    public int GetMPPoint()
    {
        return h_MPPoint;
    }

    public void PlusMPPoint()
    {
        h_MPPoint += 1;
        PlayerPrefs.SetInt("MPPoint", h_MPPoint);
    }

    public void MinusMPPoint()
    {
        h_MPPoint -= 1;
        PlayerPrefs.SetInt("MPPoint", h_MPPoint);
    }

    public void UpLvE()
    {
        
        if (GetGold() >= h_GoldE&& h_LvE<50)
        {
            AudioManager.instance.Play("Buy");
            h_LvE += 1;
            PlayerPrefs.SetInt("LVE", h_LvE);
            DecreaseGold(h_GoldE);
            h_GoldE += (int)(h_GoldE / 5);

            PlayerPrefs.SetFloat("GoldE", h_GoldE);
            PlusBonusE();
        }
        else
        {
            return;
        }
        
    }

    public float GetBonusE()
    {
        return h_BonusEnegry;
    }
    public int GetLvE()
    {
        return h_LvE;
    }

    public void PlusBonusE()
    {
        h_BonusEnegry += 8;
        PlayerPrefs.SetFloat("BonusE", h_BonusEnegry);
    }
    

    public float GetGoldE()
    {
        return h_GoldE;
    }

    

    public void PlusMaxEnergy(float h)
    {
        h_MaxEnergyFly += h;
        PlayerPrefs.SetFloat("MaxEnergyPlayer", h_MaxEnergyFly);
        SetMaxValue();
    }

    public float GetTotalE()
    {

        if (h_TotalE < (h_MaxEnergyFly + h_BonusEnegry))
        {
            h_TotalE = h_MaxEnergyFly + h_BonusEnegry;
            PlayerPrefs.SetFloat("TotalE", h_TotalE);
        }
        else
        {
            h_TotalE = PlayerPrefs.GetFloat("TotalE");
        }
        SetMaxValue();
        return h_TotalE;
    }
    public float GetEnergy1()
    {
        GameObject point = Instantiate(h_HpPopUp[1], new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), quaternion.identity);
        point.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "-" + 20;

        h_CurrentEnergyFly -= 20;
        
        if (h_CurrentEnergyFly <= 0)
        {
            h_CurrentEnergyFly = 0;
        }
        return h_CurrentEnergyFly ;
        
    }

    public void HealEnergy()
    {
        if (GetMPPoint() > 0)
        {
            MinusMPPoint();
            AudioManager.instance.Play("Heal");
            StartCoroutine(HealEnegryEvery());
        }
        else
        {
            return;
        }
       
    }
    private IEnumerator HealEnegryEvery()
    {
        float healEnegry = 0;
        while (healEnegry<50)
        {
            GameObject point = Instantiate(h_HpPopUp[1], new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), quaternion.identity);
            point.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "+" + 10;

            healEnegry += 10;
            yield return new WaitForSeconds(0.1f);
            
                h_CurrentEnergyFly += 10;
                if (h_CurrentEnergyFly >h_TotalE)
                {
                    h_CurrentEnergyFly = h_TotalE;  
                }
               
            
        }
    }
    private IEnumerator HealEnegryEveryFiveSecon()
    {
       
        while (true)
        {
            
            
            if (h_CurrentEnergyFly < h_MaxEnergyFly)
            {
                GameObject point = Instantiate(h_HpPopUp[1], new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), quaternion.identity);
                point.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "+" + 5;

                h_CurrentEnergyFly += 5;
                if (h_CurrentEnergyFly > h_MaxEnergyFly)
                {
                    h_CurrentEnergyFly = h_MaxEnergyFly;
                }
            }

            yield return new WaitForSeconds(5f);

        }
    }


    // Set/Get Health Player
    public int GetHPPoint()
    {
        return h_HPPoint;
    }

    public void PlusHPPoint()
    {
        h_HPPoint += 1;
        PlayerPrefs.SetInt("HPPoint", h_HPPoint);
    }

    public void MinusHPPoint()
    {
        h_HPPoint -= 1;
        PlayerPrefs.SetInt("HPPoint", h_HPPoint);
    }
    public void UpLvHP()
    {
        if (GetGold() >= h_GoldHP && h_LvHP < 50)
        {
            AudioManager.instance.Play("Buy");
            h_LvHP += 1;
            PlayerPrefs.SetInt("LVHP", h_LvHP);
            DecreaseGold(h_GoldHP);
            h_GoldHP += (int)(h_GoldHP / 5);

            PlayerPrefs.SetFloat("GoldHP", h_GoldHP);
            PlusBonusHP(50);
        }
        else
        {
            return;
        }
           
    }
    public void PlusMaxHP(float h)
    {
        h_MaxHp += h;
        PlayerPrefs.SetFloat("MaxHPPlayer", h_MaxHp);
       
    }
    public float GetGoldHP()
    {
        return h_GoldHP;
    }

    public int GetLvHP()
    {
        return h_LvHP;
    }

    public bool GetIsDead()
    {
        return h_IsDead;
    }

    public bool GetIsDizzy()
    {
        return h_IsDizzy;
    }

    public void ChangeDizzy()
    {
        
        StartCoroutine(SetDizzy());
    }

    IEnumerator SetDizzy()
    {
        h_IsDizzy = true;
        yield return new WaitForSeconds(0.2f); 
        h_IsDizzy = false; 
    }
    public void HealHP()
    {
        if (GetHPPoint() > 0)
        {
            MinusHPPoint();
            AudioManager.instance.Play("Heal");
            StartCoroutine(HealHPEveryTime());
        }
       
  
    }

    private IEnumerator HealHPEveryTime()
    {
        float heal = 0;
        while(heal<200)
        {
            heal += 20;
            GameObject point = Instantiate(h_HpPopUp[0], new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), quaternion.identity);
            point.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "+" + 20;
            h_CurrentHp += 20;
            if (h_CurrentHp > h_TotalHP)
            {
                h_CurrentHp = h_TotalHP;

            }
            yield return new WaitForSeconds(0.1f);
        }
    }
    public float GetCurrentHP()
    {
        return h_CurrentHp;
    }

    public void PlusBonusHP(float hp)
    {
        h_BonusHP += hp;
        PlayerPrefs.SetFloat("BonusHPPlayer", h_BonusHP);
        
    }
    public float GetTotalHP()
    {

        if (h_TotalHP < (h_MaxHp+h_BonusHP)) 
        {
            h_TotalHP = h_MaxHp + h_BonusHP;
            PlayerPrefs.SetFloat("TotalHP", h_TotalHP);
        }
        else
        {
            h_TotalHP = PlayerPrefs.GetFloat("TotalHP");
        }
        SetMaxValue();
        return h_TotalHP;
    }
    public void PlayerDead()
    {
       GameObject gameObject= base.FindObjectWithTag("Player01");
        h_IsDead = true;
        AudioManager.instance.Play("Dead");
        
       Destroy(gameObject,0.5f);
       
    }
   public void PlayerTakeDamage(float damage)
    {
        h_CurrentHp -= (int)(damage - (GetTotalDEF() / 15 * 2));
        Vector3 vector3= transform.position;
        vector3.x = transform.position.x-0.5f;
        
        GameObject point= Instantiate(h_HpPopUp[0], new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), quaternion.identity);
        point.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text= "-" + (int)(damage - (GetTotalDEF() / 15 * 2));

        Animator animator =GetComponent<Animator>();
        
        AudioManager.instance.Play("Hurt");
        animator.SetTrigger("IsHurt");
        if (h_CurrentHp <= 0)
        {
            h_CurrentHp = 0;
            PlayerDead();
        }
    }


    // Set/Get EXP Player
    public float GetEXP()
    {
        return h_CurrentExp;
    }
    public float GetMaxEXP()
    {
        return h_MaxExp;
    }
    
    
    public void PlayerTakeExp(float exp)
    {
        GameObject point = Instantiate(h_HpPopUp[2], new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), quaternion.identity);
        point.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "+" + exp;

        h_CurrentExp += exp;
        PlayerPrefs.SetFloat("CurrentEXP", h_CurrentExp);
        if (h_CurrentExp >= h_MaxExp)
        {
            AudioManager.instance.Play("LV");
            GameObject point1 = Instantiate(h_HpPopUp[2], new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), quaternion.identity);
            point1.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Level Up";

            h_CurrentLevel += 1;
            PlusATK(5);
            PlusDEF(10);
            PlusMaxHP(25);
            PlusMaxEnergy(5);
            PlayerPrefs.SetFloat("LevelPlayer", h_CurrentLevel);
            h_CurrentExp -= h_MaxExp;
            PlayerPrefs.SetFloat("CurrentEXP", h_CurrentExp);
            h_IsLevelUp = true;
            MaxExpUp();
        }
    }

    
    protected void MaxExpUp()
    {
        if (h_IsLevelUp==true)
        {
            h_MaxExp += (int)(h_MaxExp / 15);
            PlayerPrefs.SetFloat("MaxEXP", h_MaxExp);
            SetMaxValue();
            h_IsLevelUp = false;
        }
    }

    public float GetLevel()
    {
        return h_CurrentLevel;
    }


    //Set/Get ATK Player
    public void UpLvATK()
    {
        if (GetGold() >= h_GoldATK && h_LvATK < 50)
        {
            AudioManager.instance.Play("Buy");
            h_LvATK += 1;
            PlayerPrefs.SetInt("LVATK", h_LvATK);
            DecreaseGold(h_GoldATK);
            h_GoldATK += (int)(h_GoldATK / 5);

            PlayerPrefs.SetFloat("GoldATK", h_GoldATK);
            BonusATK(10);
        }
        else
        {
            return;
        }
        
    }
    public int GetLvATK()
    {
        return h_LvATK;
    }
    public float GetTotalATK()
    {
        if (h_TotalATK < (h_MaxATK + h_BonusATK))
        {
            h_TotalATK=h_MaxATK +h_BonusATK;
            PlayerPrefs.SetFloat("TotalATK", h_TotalATK);
        }
        
        return h_TotalATK;
    }

    public float GetGoldATK()
    {
        return h_GoldATK;
    }
    public float GetBonusATK()
    {
        return h_BonusATK;
    }
    public void BonusATK(float atk)
    {
        h_BonusATK += atk;
        PlayerPrefs.SetFloat("BonusATK", h_BonusATK);
    }
    
    public void PlusATK(float atk)
    {
        h_MaxATK += atk;
        PlayerPrefs.SetFloat("ATKPlayer", h_MaxATK);
       
    }

    // Set/Get Def Player
    public void UpLvDEF()
    {
        if (GetGold() >= h_GoldDEF && h_LvDEF < 50)
        {
            AudioManager.instance.Play("Buy");
            h_LvDEF += 1;
            PlayerPrefs.SetInt("LVDEF", h_LvDEF);
            DecreaseGold(h_GoldDEF);
            h_GoldDEF += (int)(h_GoldDEF / 5);

            PlayerPrefs.SetFloat("GoldDEF", h_GoldDEF);
            BonusDEF(10);
        }
        else
        {
            return;
        }
           
           
    }
    public int GetLvDEF()
    {
        return h_LvDEF;
    }
    public float GetTotalDEF()
    {
        if (h_TotalDEF < (h_MaxDEF + h_BonusDEF))
        {
            h_TotalDEF=h_MaxDEF+h_BonusDEF;
            PlayerPrefs.SetFloat("TotalDEF",h_TotalDEF);
        }
        return h_TotalDEF;
    }

    public float GetBonusDEF()
    {
        return h_BonusDEF;
    }

    public void PlusDEF(float def)
    {
        h_MaxDEF += def;
        PlayerPrefs.SetFloat("DEFPlayer", h_MaxDEF);
    }
    public void BonusDEF(float def)
    {
        h_BonusDEF += def;
        PlayerPrefs.SetFloat("BonusDEF", h_BonusDEF);
    }

    public float GetGoldDEF()
    {
        return h_GoldDEF;
    }

    // Set/Get Gold
    public float GetGold()
    {
        return h_Gold;
    }

    public void TakeGold(float gold)
    {
        h_Gold += gold;
        PlayerPrefs.SetFloat("Gold", h_Gold);
    }

    public void DecreaseGold(float gold)
    {
        
        
            h_Gold -= gold;
            PlayerPrefs.SetFloat("Gold", h_Gold);
        
        
        
    }


    //Key
    public int GetKey()
    {
        return h_Key;
    }

    public void PlusKey()
    {
        h_Key += 1;
    }

    
}