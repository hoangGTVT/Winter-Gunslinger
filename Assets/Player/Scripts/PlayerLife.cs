using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : FindObject
{
    protected static PlayerLife instance;
    public static PlayerLife Instance { get => instance; }
    [SerializeField] public static bool h_Isdead=false;

    [SerializeField] protected int h_MaxHp;
    [SerializeField] protected int h_CurrentHp;

   
    [SerializeField] protected int h_CurrentATK;

    
    [SerializeField] protected int h_CurrentDEF;

    [SerializeField] protected int h_MaxExp=100;
    [SerializeField] protected int h_CurrentExp;
    [SerializeField] protected int h_CurrentLevel=1;
    [SerializeField] protected bool h_IsLevelUp=false;

    private void Start()
    {
        
        h_CurrentHp= 200;
        h_CurrentExp = 0;
        h_CurrentLevel= 1;
        Debug.Log(h_CurrentHp);
        Debug.Log(h_CurrentLevel);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            PlayerTakeDamage(20);
          
            Debug.Log(h_CurrentHp);

        }
        if (Input.GetKeyDown(KeyCode.M))
        {
           
            PlayerTakeExp(20);
            Debug.Log(h_CurrentLevel);
            Debug.Log(h_CurrentExp);
        }
        
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Dead"))
        {
            PlayerDead();
        }
    }

    public void GetHP()
    {
        h_CurrentHp = h_MaxHp;
    }
    public void PlayerDead()
    {
       GameObject gameObject= base.FindObjectWithTag("Player01");
       Destroy(gameObject);
    }
   protected void PlayerTakeDamage(int damage)
    {
        h_CurrentHp-=damage;
    }

    protected void PlayerTakeExp(int exp)
    {
        h_CurrentExp += exp;
        if (h_CurrentExp >= h_MaxExp)
        {
            h_CurrentLevel += 1;
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
            h_IsLevelUp = false;
        }
    }
    
}