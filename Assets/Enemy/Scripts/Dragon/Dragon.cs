using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    private SpriteRenderer sprite;
    public Animator animator;
    [SerializeField] public GameObject h_BulletEnemy;
    public bool h_IsShoot = true;
    public int speed = 3;
    public Transform h_PointShooting;
    [SerializeField] GameObject h_HP;

    

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Attack1()
    {
        if (h_PointShooting != null)
        {
            h_IsShoot = false;
            GameObject game = Instantiate(h_BulletEnemy, h_PointShooting.position, Quaternion.identity);
            AudioManager.instance.Play("EnemyAttack");

            h_IsShoot = true;
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
            float enemyX = transform.position.x;
            float playerX = playerTransform.position.x;
            if (direction <= 8 && direction > 4 && Box.h_IsRun==true)
            {
                animator.SetInteger("State", 1);

            }
            else if (direction > 6)
            {
                animator.SetInteger("State", 0);
            }

            if (direction <= 4f)
            {
                animator.SetTrigger("IsAttack");


            }


            if (playerX > enemyX && direction<=6)
            {
                Vector3 newRotation = transform.eulerAngles;
                newRotation.y = 0; // Đặt góc y về 0
                transform.eulerAngles = newRotation;
            }
            else if (playerX < enemyX &&direction <= 6)
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
    public void FindPlayer1()
    {
        GameObject player01Animation = GameObject.FindGameObjectWithTag("Player01Animation");

        if (player01Animation != null)
        {

            Transform playerTransform = player01Animation.transform;
            float direction = Vector3.Distance(playerTransform.position, transform.position);
            float enemyX = transform.position.x;
            float playerX = playerTransform.position.x;
            if (Box.h_IsRun == true)
            {
                if (direction > 4)
                {
                    // Tính toán hướng di chuyển của đối thủ
                    Vector3 targetPosition = new Vector3(playerTransform.position.x, transform.position.y, transform.position.z);

                    // Di chuyển đối thủ theo người chơi
                    transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                }
                
               
            }
            else if(Box.h_IsRun==false)
            {
                animator.SetInteger("State", 0);
               
            }
            

            




            if (direction <= 4f)
            {
                animator.SetTrigger("IsAttack");


            }else if (direction > 6)
            {
                animator.SetInteger("State", 0);
            }
            if (playerX > enemyX && direction <= 6)
            {
                Vector3 newRotation = transform.eulerAngles;
                newRotation.y = 0; // Đặt góc y về 0
                transform.eulerAngles = newRotation;
            }
            else if (playerX < enemyX && direction <= 6)
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
