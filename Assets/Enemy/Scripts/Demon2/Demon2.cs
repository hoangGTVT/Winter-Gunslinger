using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon2 : MonoBehaviour
{
    private SpriteRenderer sprite;
    private Animator animator;
    [SerializeField] public GameObject h_BulletEnemy;
    public float h_IsShoot = 2;

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
        h_IsShoot-= Time.deltaTime;
    }

    public void Attack1()
    {
        if (h_PointShooting != null )
        {
            
            GameObject game = Instantiate(h_BulletEnemy, h_PointShooting.position, Quaternion.identity);
            AudioManager.instance.Play("EnemyAttack");
            h_IsShoot=2;
            
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

            if (direction <= 7f && h_IsShoot <= 0)
            {
                animator.SetTrigger("IsAttack");

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
