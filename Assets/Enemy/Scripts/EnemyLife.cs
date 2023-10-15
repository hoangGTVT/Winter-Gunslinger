using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyLife : FindObject
{
    public HpBarEnemy barEnemy; 
    public PlayerLife playerLife;
    public float h_IndexHP = 2;
    public int h_HPbonus;

    [SerializeField] protected float h_MaxHP;
    [SerializeField] protected float h_CurrentHP;
    [SerializeField] protected TextMeshProUGUI[] textMeshProUGUI;

    public GameObject itemPrefab; // Thiết lập prefab của item trong Inspector
    public GameObject bat;
    private void Awake()
    {
        if (PlayerPrefs.GetFloat("LevelPlayer") < 10)
        {
            h_HPbonus = 50;
        }
        else if(PlayerPrefs.GetFloat("LevelPlayer") >= 10)
        {
            int hp = (int)PlayerPrefs.GetFloat("LevelPlayer");
            h_HPbonus = (( (hp/ 10)+1) * 50);
        }
    }
    void Start()
    {
        
        SetMaxHP();
       
    }

    // Update is called once per frame
    void Update()
    {
        FindPlayer();
        ShowText();
       
    }

    public void ShowText() {
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
       
        SetHP();
        if (h_CurrentHP <= 0) {
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
            EnemyDead();
        }
    }


    public void EnemyDead()
    {
       
        
        playerLife.PlayerTakeExp(playerLife.GetLevel() + 20);

        float drop = 0.5f;
        if (Random.value <= drop)
        {
            // Tạo một bản sao của itemPrefab và đặt nó tại vị trí của enemy
            Instantiate(itemPrefab, transform.position, Quaternion.identity);
            
        }
       
        Destroy(gameObject);
    }
    

}


