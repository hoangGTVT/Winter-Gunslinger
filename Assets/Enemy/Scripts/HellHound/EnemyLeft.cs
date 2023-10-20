using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLeft : MonoBehaviour
{
    public SpriteRenderer sprite;
    public Animator animator;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        FindPlayer1();
    }
    
    public void FindPlayer1()
    {
        GameObject player01Animation = GameObject.FindGameObjectWithTag("Player01Animation");

        if (player01Animation != null)
        {
            Transform playerTransform = player01Animation.transform;


            float direction = Vector3.Distance(playerTransform.position, transform.position);

            if (direction <= 5f )
            {
                animator.SetInteger("State", 1);

            }
            else
            {
                animator.SetInteger("State", 0);
            }
            float enemyX = transform.position.x;
            float playerX = playerTransform.position.x;

            if (playerX > enemyX)
            {
                sprite.flipX = true;
            }
            else if (playerX < enemyX)
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
