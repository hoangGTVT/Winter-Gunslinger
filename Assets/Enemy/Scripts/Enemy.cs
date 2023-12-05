using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.U2D;

public class Enemy : FindObject
{
    public GameObject hpFloat;
    public HpBarEnemy barEnemy;
    public PlayerLife playerLife;
    public float h_IndexHP = 2;
    public int h_HPbonus;
    public bool h_ItemSpawn = false;
    public bool h_ItemSpawn1 = false;
    public bool h_ItemSpawn2 = false;
    public int h_Exp = 20;
    public SpriteRenderer sprite;
    public Animator animator;
    
    public bool h_IsShoot = true;

   

    public Vector3 attackOffset;
    public float attackRange = 1f;
    public LayerMask attackMask;
    public bool isRight=true;


    [SerializeField] protected float h_MaxHP;
    [SerializeField] protected float h_CurrentHP;
    [SerializeField] protected TextMeshProUGUI[] textMeshProUGUI;

    public GameObject[] itemPrefab; // Thiết lập prefab của item trong Inspector
    
    private void Awake()
    {
        SetHpBonus();
    }
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        SetMaxHP();
        animator = GetComponent<Animator>();    
        //InvokeRepeating("BatDie", 10, 10);
       
    }

    // Update is called once per frame
    void Update()
    {
        FindPlayer();
        ShowText();
        


    }

   public void SetHpBonus()
    {
        if (PlayerPrefs.GetFloat("LevelPlayer") < 5)
        {
            h_HPbonus = 50;
        }
        else if (PlayerPrefs.GetFloat("LevelPlayer") >= 5)
        {
            int hp = (int)PlayerPrefs.GetFloat("LevelPlayer");
            h_HPbonus = (((hp / 5) + 1) * 50);
        }
      
        
    }
    public void ShowText()
    {
        textMeshProUGUI[0].text = "/" + h_MaxHP;
        textMeshProUGUI[1].text = "" + h_CurrentHP;
    }

    
    


    public float CurrentHP()
    {
        return h_CurrentHP;
    }
    public void SetMaxHP()
    {

        h_MaxHP = h_IndexHP * h_HPbonus;
        h_CurrentHP = h_IndexHP * h_HPbonus;
        barEnemy.SetMaxHealth(h_CurrentHP);
    }

    public void SetHP()
    {
        barEnemy.SetHealth(h_CurrentHP);
    }

    public void TakeDamege(float damage)
    {
        h_CurrentHP -= (int)damage;
        GameObject point = Instantiate(hpFloat, new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), Quaternion.identity);
        point.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "-" + damage;

        SetHP();
        if (h_CurrentHP <= 0)
        {
            h_CurrentHP = 0;
            EnemyDead();
        }


    }



    protected void FindPlayer()
    {
        GameObject gameObject = base.FindObjectWithTag("Player01Animation");
        if (gameObject != null)
        {
            playerLife = gameObject.GetComponent<PlayerLife>();
            



        }
        else
        {
            playerLife = null;
            
        }

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            
            TakeDamege(playerLife.GetTotalATK());
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player01Animation"))
        {
            BatDie();
        }
    }

    public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (colInfo != null)
        {
            colInfo.GetComponent<PlayerLife>().PlayerTakeDamage(500);
        }
    }
    public void EnemyDead()
    {

        if (!h_ItemSpawn2)
        {
            playerLife.PlayerTakeExp(playerLife.GetLevel() + h_Exp);
            h_ItemSpawn2 = true;
        }
        
        if (!h_ItemSpawn1)
        {
            Instantiate(itemPrefab[0], transform.position, Quaternion.identity);
            h_ItemSpawn1 = true;
        }
        float drop = 0.5f;
        int randomNumber = Random.Range(0, 2);
        if (Random.value <= drop)
        {
            if (randomNumber == 0 && !h_ItemSpawn)
            {

                Instantiate(itemPrefab[1], transform.position, Quaternion.identity);
                h_ItemSpawn = true;

            }
            else if (randomNumber == 1 && !h_ItemSpawn)
            {

                Instantiate(itemPrefab[2], transform.position, Quaternion.identity);
                h_ItemSpawn = true;
            }

        }

        BatDie();
    }

    public void BatDie()
    {
        Destroy(gameObject);
    }
}
