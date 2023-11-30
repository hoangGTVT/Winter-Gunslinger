using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject hpFloat;
    public HpBarEnemy barEnemy;
    public PlayerLife playerLife;
    public SpriteRenderer sprite;
    public Animator animator;

    public Vector3 attackOffset;
    public float attackRange = 1f;
    public LayerMask attackMask;

    public bool h_ItemSpawn = false;
    public bool h_ItemSpawn1 = false;
    public bool h_ItemSpawn2 = false;
    public int h_BonusHP;
    public static bool isTakeDamage = false;

    [SerializeField] public float h_Exp;
    [SerializeField] protected float h_MaxHP;
    [SerializeField] protected float h_CurrentHP;
    [SerializeField] protected TextMeshProUGUI[] textMeshProUGUI;
    public GameObject[] itemPrefab;

    private void Awake()
    {
        if (PlayerPrefs.GetFloat("ATKPlayer") <= 15)
        {
            h_MaxHP = 500;
            
        }
        else
        {
            h_MaxHP = PlayerPrefs.GetFloat("ATKPlayer") * h_BonusHP;
        }
        
    }
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        SetMaxHP();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ShowText();
        FindPlayer();
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

       
        h_CurrentHP = h_MaxHP;
        barEnemy.SetMaxHealth(h_CurrentHP);
    }

    public void SetHP()
    {
        barEnemy.SetHealth(h_CurrentHP);
    }

    public void HealHP()
    {
        h_CurrentHP += 50;
        SetHP();
        if (h_CurrentHP > h_MaxHP)
        {
            h_CurrentHP = h_MaxHP;
            SetHP() ;
        }
    }
    public void HealHP1()
    {
        while(h_CurrentHP < h_MaxHP) { 

            h_CurrentHP+=200;
            SetHP();
            if (h_CurrentHP > h_MaxHP)
            {
                h_CurrentHP = h_MaxHP;
                SetHP();
            }
        }

       
        
    }

    public void TakeDamege(float damage)
    {
        
        
            h_CurrentHP -= (int)damage;
            animator.SetTrigger("IsHurt");
            GameObject point = Instantiate(hpFloat, new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), Quaternion.identity);
            point.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "-" + damage;

            SetHP();
        
       
       
       
        
        if (h_CurrentHP <= 0)
        {
            GameObject gameObject = GameObject.FindGameObjectWithTag("PointLife");
            if (gameObject != null)
            {
                HealHP1();
            }
            else
            {
                h_CurrentHP = 0;
                BossDead1();
            }
            
        }


    }

    protected void FindPlayer()
    {
        GameObject gameObject = GameObject.FindGameObjectWithTag("Player01Animation");
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
            if(playerLife!=null)
            {
                if (isTakeDamage == true) { return; }
                TakeDamege((int)(playerLife.GetTotalATK() / 2));
            }
            else
            {
                return;
            }
            
           
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player01Animation"))
        {
            playerLife.PlayerTakeDamage(playerLife.GetTotalHP());
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

    public void BossDead()
    {
        animator.SetTrigger("IsDead");
        
        Destroy(gameObject,1);
    }

    public void BossDead1()
    {

        if (!h_ItemSpawn2)
        {
            playerLife.PlayerTakeExp(playerLife.GetLevel() + h_Exp);
            
            Instantiate(itemPrefab[3], transform.position, Quaternion.identity);
            h_ItemSpawn2 = true;
        }
        
        
        
            
            
                Instantiate(itemPrefab[0], transform.position, Quaternion.identity);
                Instantiate(itemPrefab[1], transform.position, Quaternion.identity);
                Instantiate(itemPrefab[2], transform.position, Quaternion.identity);
                h_ItemSpawn1 = true;
                
            
        
        

       BossDead();
    }
}
