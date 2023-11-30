using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JinMagic : MonoBehaviour
{
    public Vector3 attackOffset;
    public float attackRange = 1f;
    public LayerMask attackMask;
    public float h_PlusDamage;

    private Rigidbody2D rb;
    [SerializeField] protected int h_BulletSpeed = 3;
   

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
        //Destroy(gameObject, 0.6f);
        FindPlayer();
    }

    public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;
        Collider2D col = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (col != null)
        {
            col.GetComponent<PlayerLife>().PlayerTakeDamage(col.GetComponent<PlayerLife>().GetTotalATK() + h_PlusDamage);
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
            Destroy(gameObject, 0.7f);
        }
        else
        {
            Destroy(gameObject, 0.7f);
            return;
        }
    }
}
