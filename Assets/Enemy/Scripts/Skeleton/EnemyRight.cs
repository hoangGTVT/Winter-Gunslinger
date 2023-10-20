using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class EnemyRight : MonoBehaviour
{
    private SpriteRenderer sprite;
    private Animator animator;
    [SerializeField] GameObject h_BulletEnemy;
    public bool h_IsShoot = true;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //FindPlayer2();
       
    }
   
    public void Attack1()
    {
        h_IsShoot = false;
        GameObject game = Instantiate(h_BulletEnemy, transform.position, Quaternion.identity);
        AudioManager.instance.Play("EnemyAttack");

        h_IsShoot = true;
    }

    public void FindPlayer2()
    {
        GameObject player01Animation = GameObject.FindGameObjectWithTag("Player01Animation");

        if (player01Animation != null)
        {
            Transform playerTransform = player01Animation.transform;

            float direction = Vector3.Distance(playerTransform.position, transform.position);

            if (direction <= 5f && h_IsShoot==true)
            {
                animator.SetTrigger("IsAttack");

            }
            float enemyX = transform.position.x;
            float playerX = playerTransform.position.x;

            if (playerX < enemyX)
            {
                sprite.flipX = true;
            }
            else if (playerX > enemyX)
            {
                sprite.flipX = false;
            }
        }
        else
        {
            return;
        }

    }

}
