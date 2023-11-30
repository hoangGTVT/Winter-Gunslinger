using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Unded : MonoBehaviour
{
    private Animator animator;
    [SerializeField] public GameObject h_BulletEnemy;
    [SerializeField] public Transform h_BulletEnemyTransform;
    
    [SerializeField] float h_TimeAttack = 1;

    [SerializeField] GameObject h_HP;
    void Start()
    {
        
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        h_TimeAttack -= Time.deltaTime;
        FindPlayer2();

    }
    public void Attack1()
    {
        GameObject gameObject = GameObject.FindGameObjectWithTag("Player01Animation");
        if (gameObject != null)
        {
            
            GameObject game = Instantiate(h_BulletEnemy, h_BulletEnemyTransform.transform.position, Quaternion.identity);
            AudioManager.instance.Play("EnemyAttack");
        }
        else
        {
            return;
        }


    }
    public void FindPlayer2()
    {
        GameObject player01Animation = GameObject.FindGameObjectWithTag("Player01Animation");

        if (player01Animation != null)
        {
            Transform playerTransform = player01Animation.transform;

            float direction = Vector3.Distance(playerTransform.position, transform.position);

            if (direction <= 6f && h_TimeAttack <= 0)
            {
                animator.SetTrigger("IsAttack");
                h_TimeAttack = 1;

            }




            float enemyX = transform.position.x;
            float playerX = playerTransform.position.x;

            if (playerX > enemyX)
            {
                Vector3 newRotation = transform.eulerAngles;
                newRotation.y = 0; // Đặt góc y về 0
                transform.eulerAngles = newRotation;
            }
            else if (playerX < enemyX)
            {
                Vector3 newRotation = transform.eulerAngles;
                newRotation.y = 180; // Đặt góc y về 180 để quay ngược lại
                transform.eulerAngles = newRotation;
            }
            h_HP.transform.rotation = Quaternion.identity;
        }
        else
        {
            return;
        }

    }
}
