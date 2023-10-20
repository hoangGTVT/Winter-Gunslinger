using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class BulletEnemy : FindObject
{
    private Rigidbody2D rb;
    [SerializeField] protected int h_BulletSpeed = 3;
    public float h_PlusDamege;

    private SpriteRenderer sprite;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        FindPlayer();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    protected void FindPlayer()
    {
        GameObject playerObject = GameObject.FindWithTag("Player01Animation");

        if (playerObject != null)
        {
            Transform playerTransform = playerObject.transform;
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
            Vector3 playerPosition = playerObject.transform.position;

            // Tính hướng bắn tĩnh từ vị trí hiện tại của đạn đến vị trí của người chơi
            Vector3 shootingDirection = (playerPosition - transform.position).normalized;

            // Đặt tốc độ cho đạn và bắn nó
            rb.velocity = shootingDirection * h_BulletSpeed;

            // Hủy đạn sau một khoảng thời gian
            Destroy(gameObject, 1.5f);
        }
        else
        {
            return;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player01Animation"))
        {
            Destroy(gameObject);
            PlayerLife playerLife= collision.gameObject.GetComponent<PlayerLife>();
            playerLife.PlayerTakeDamage(playerLife.GetTotalATK()+h_PlusDamege);
        }
    }
}
