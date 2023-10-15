using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoment : FindObject
{

    public Rigidbody2D rb;
    private SpriteRenderer sprite;
    public float moveSpeed = 2f;
    public GameObject h_BulletEnemy;
    public bool h_IsShoot = true;
     


     void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        FindPlayer();
    }

    protected void FindPlayer()
    {
        GameObject gameObject1 = base.FindObjectWithTag("Player01Animation");
        
        if (gameObject1 != null)
        {
            Transform player = gameObject1.transform;
            float direction = Vector3.Distance( player.position, transform.position);
            
            if(direction<=5f&& h_IsShoot)
            {
                StartCoroutine(Shoot());
                
            }
            float enemyX = transform.position.x;
            float playerX = player.position.x;
            if (playerX > enemyX)
            {
               sprite.flipX = true;
            }
            else if (playerX < enemyX)
            {
                sprite.flipX=false;
            }
        }
        else
        {
            return;
        }

    }

    IEnumerator Shoot()

    {
        h_IsShoot = false;
        GameObject game = Instantiate(h_BulletEnemy, transform.position, Quaternion.identity);
        AudioManager.instance.Play("EnemyAttack");
        yield return new WaitForSeconds(3f);
        h_IsShoot=true;
    }


}
