using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class BulletBoss : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] protected int h_BulletSpeed = 3;
    public float h_PlusDamege;

    private SpriteRenderer sprite;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        FindPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player01Animation")){
            PlayerLife playerLife=collision.gameObject.GetComponent<PlayerLife>();  
            if (playerLife != null)
            {
                playerLife.PlayerTakeDamage(playerLife.GetTotalATK()+h_PlusDamege);
                Destroy(gameObject);
            }
            else
            {
                return;
            }
        }
    }

    protected void FindPlayer()
    {
        GameObject playerObject = GameObject.FindWithTag("Player01Animation");

        if (playerObject != null)
        {
            Transform playerTransform = playerObject.transform;
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
            Vector3 playerPosition = playerObject.transform.position;

            // Tính hướng bắn tĩnh từ vị trí hiện tại của đạn đến vị trí của người chơi
            Vector3 shootingDirection = (playerPosition - transform.position).normalized;
            float angle = Mathf.Atan2(shootingDirection.y, shootingDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

            // Đặt tốc độ cho đạn và bắn nó
            rb.velocity = shootingDirection * h_BulletSpeed;

            // Hủy đạn sau một khoảng thời gian
            Destroy(gameObject, 1.5f);
        }
        else
        {
            Destroy(gameObject, 1.5f);
            return;
        }
    }
}
