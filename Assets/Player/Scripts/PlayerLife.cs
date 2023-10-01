using System.Collections;
using UnityEngine;

public class PlayerLife : FindObject
{
    
    public UIBar bar;
   
    [SerializeField] public static bool h_Isdead=false;

    // HP
    [SerializeField] protected int h_MaxHp=100;
    [SerializeField] protected int h_CurrentHp;

   // ATK
    [SerializeField] protected int h_CurrentATK;

    // Energy
    [SerializeField] protected int h_MaxEnergyFly ;
    [SerializeField] protected int h_CurrentEnergyFly;

    // DEF
    [SerializeField] protected int h_CurrentDEF;

    // EXP
    [SerializeField] protected int h_MaxExp=100;
    [SerializeField] protected int h_CurrentExp;
    [SerializeField] protected int h_CurrentLevel=1;
    [SerializeField] protected bool h_IsLevelUp=false;
    [SerializeField] protected float h_EnergyCooldown = 5f;
    [SerializeField] bool h_canEnergy = true;

    //Gold
    [SerializeField] protected int h_Gold;
    private void Awake()
    {

        
        FindUiBar();
        GetStartValue();
        
    }
    private void Start()
    {
        SetMaxValue();
        StartCoroutine(EnegryOverTime());
       
        
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
        if (Input.GetKeyDown(KeyCode.N))
        {
            TakeGold(20);
          
           
            

        }
        if (Input.GetKeyDown(KeyCode.M))
        {
           
            PlayerTakeExp(20);
            
        }

        if (Input.GetKeyDown(KeyCode.B))
        {

            PlusMaxHP(50);
        }
        if (Input.GetKeyDown(KeyCode.V))
        {

            PlayerTakeDamage(50);
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
        if (PlayerPrefs.GetInt("MaxHPPlayer") < 200)
        {
            h_MaxHp = 200;
            h_CurrentHp = 200;
        }
        else
        {
            h_MaxHp = PlayerPrefs.GetInt("MaxHPPlayer");
            h_CurrentHp = PlayerPrefs.GetInt("MaxHPPlayer");
        }

        // Set Energy
        if (PlayerPrefs.GetInt("MaxEnergyPlayer") < 100)
        {
            h_MaxEnergyFly = 100;
            h_CurrentEnergyFly = 100;
        }
        else
        {
            h_MaxEnergyFly = PlayerPrefs.GetInt("MaxEnergyPlayer");
            h_CurrentEnergyFly = PlayerPrefs.GetInt("MaxEnergyPlayer");
        }

        //Set Level
        
        if (PlayerPrefs.GetInt("LevelPlayer") < 1)
        {
            h_CurrentLevel = 1;
            PlayerPrefs.SetInt("LevelPlayer", h_CurrentLevel);
        }
        else
        {
            h_CurrentLevel = PlayerPrefs.GetInt("LevelPlayer");
        }

        //Set EXP
        h_CurrentExp = PlayerPrefs.GetInt("CurrentEXP");
        if (PlayerPrefs.GetInt("MaxEXP") < 100)
        {
            h_MaxExp = 100;
            PlayerPrefs.SetInt("MaxEXP", h_MaxExp);
        }
        else
        {
            h_MaxExp = PlayerPrefs.GetInt("MaxEXP");
        }

        //Set ATK
        if (PlayerPrefs.GetInt("ATKPlayer") < 15)
        {
            h_CurrentATK = 15;
            PlayerPrefs.SetInt("ATKPlayer", h_CurrentATK);
        }
        else
        {
            h_CurrentATK = PlayerPrefs.GetInt("ATKPlayer");
        }

        //Set DEF
        if (PlayerPrefs.GetInt("DEFPlayer") < 100)
        {
            h_CurrentDEF = 100;
            PlayerPrefs.SetInt("DEFPlayer", h_CurrentDEF);
        }
        else
        {
            h_CurrentDEF = PlayerPrefs.GetInt("DEFPlayer");
        }

        //Set Gold

        if (PlayerPrefs.GetInt("Gold") == 0)
        {
            h_Gold = 0;
        }
        else
        {
            h_Gold = PlayerPrefs.GetInt("Gold");
        }

    }

    protected void SetValue()
    {
        bar.SetEnergy(h_CurrentEnergyFly);
        bar.SetEXP(h_CurrentExp);
        bar.SetHealth(h_CurrentHp);
        
    }


    protected void SetMaxValue()
    {
        bar.SetMaxEnergy(h_MaxEnergyFly);
        bar.SetMaxHealth(h_MaxHp);
        bar.SetMaxEXP(h_MaxExp);
    }

    // Set/Get Energy
    public int GetEnergy()
    {
        
        return h_CurrentEnergyFly;
    }

    public void PlusMaxEnergy(int h)
    {
        h_MaxEnergyFly += h;
        PlayerPrefs.SetInt("MaxEnergyPlayer", h_MaxEnergyFly);
        SetMaxValue();
    }

    public int GetMaxEnergy()
    {
        if (PlayerPrefs.GetInt("MaxEnergyPlayer") < h_MaxEnergyFly)
        {
            PlayerPrefs.SetInt("MaxEnergyPlayer", h_MaxEnergyFly)  ;
        }
        else
        {
            h_MaxEnergyFly = PlayerPrefs.GetInt("MaxEnergyPlayer");
        }
        return h_MaxEnergyFly;
    }
    public int GetEnergy1()
    {
        h_CurrentEnergyFly -= 2;
        if (h_CurrentEnergyFly <= 0)
        {
            return 0;
        }
        return h_CurrentEnergyFly ;
        
    }

    private IEnumerator EnegryOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(h_EnergyCooldown);
            if (h_CurrentEnergyFly < h_MaxEnergyFly)
            {
                h_CurrentEnergyFly += 10;
                if (h_CurrentEnergyFly >h_MaxEnergyFly)
                {
                    h_CurrentEnergyFly = h_MaxEnergyFly;  
                }
               
            }
        }
    }


    // Set/Get Health Player
    public void PlusMaxHP(int h)
    {
        h_MaxHp += h;
        SetMaxValue();
    }

    public void Heal(int heal)
    {
        h_CurrentHp += heal;
        if (h_CurrentHp > h_MaxHp)
        {
            h_CurrentHp = h_MaxHp;  
        }
    }
    public int GetCurrentHP()
    {
        return h_CurrentHp;
    }
    public int GetMaxHP()
    {
        if (PlayerPrefs.GetInt("MaxHPPlayer") < h_MaxHp)
        {
            PlayerPrefs.SetInt("MaxHPPlayer", h_MaxHp);
        }
        else
        {
            h_MaxHp = PlayerPrefs.GetInt("MaxHPPlayer");
        }

        return h_MaxHp;
    }
    public void PlayerDead()
    {
       GameObject gameObject= base.FindObjectWithTag("Player01");
       Destroy(gameObject);
    }
   protected void PlayerTakeDamage(int damage)
    {
        h_CurrentHp-=damage;
        if (h_CurrentHp < 0) { h_CurrentHp = 0; }
        if (h_CurrentHp <= 0)
        {
            PlayerDead();
        }
    }


    // Set/Get EXP Player
    public int GetEXP()
    {
        return h_CurrentExp;
    }
    public int GetMaxEXP()
    {
        return h_MaxExp;
    }
    
    protected void PlayerTakeExp(int exp)
    {
        h_CurrentExp += exp;
        PlayerPrefs.SetInt("CurrentEXP", h_CurrentExp);
        if (h_CurrentExp >= h_MaxExp)
        {
            h_CurrentLevel += 1;
            PlusATK(h_CurrentATK/10);
            PlusDEF(h_CurrentDEF/10);
            PlayerPrefs.SetInt("LevelPlayer", h_CurrentLevel);
            h_CurrentExp -= h_MaxExp;
            h_IsLevelUp = true;
            MaxExpUp();
        }
    }

    protected void MaxExpUp()
    {
        if (h_IsLevelUp==true)
        {
            h_MaxExp += h_MaxExp / 10;
            PlayerPrefs.SetInt("MaxEXP", h_MaxExp);
            SetMaxValue();
            h_IsLevelUp = false;
        }
    }

    public int GetLevel()
    {
        return h_CurrentLevel;
    }


    //Set/Get ATK Player

    public int GetATK()
    {
        return h_CurrentATK;
    }
    
    public void PlusATK(int atk)
    {
        h_CurrentATK += atk;
        PlayerPrefs.SetInt("ATKPlayer", h_CurrentATK);
       
    }

    // Set/Get Def Player

    public int GetDEF()
    {
        return h_CurrentDEF;
    }

    public void PlusDEF(int def)
    {
        h_CurrentDEF += def;
        PlayerPrefs.SetInt("DEFPlayer", h_CurrentDEF);
    }

    // Set/Get Gold
    public int GetGold()
    {
        return h_Gold;
    }

    public void TakeGold(int gold)
    {
        h_Gold += gold;
        PlayerPrefs.SetInt("Gold", h_Gold);
    }

    public void DecreaseGold(int gold)
    {
        h_Gold -= gold;
        if (h_Gold < 0)
        {
            h_Gold = 0;
        }
        PlayerPrefs.SetInt("Gold", h_Gold);
    }
}