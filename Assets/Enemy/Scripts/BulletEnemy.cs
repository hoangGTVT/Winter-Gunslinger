using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class BulletEnemy : FindObject
{
    private Rigidbody2D rb;
    [SerializeField] protected int h_BulletSpeed = 3;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
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
            float direction = Vector3.Distance(player.position, transform.position);


            Vector3 shootingDirection = (player.position - transform.position).normalized;

            // Đặt tốc độ cho đạn và bắn nó
            rb.velocity = shootingDirection * h_BulletSpeed;

            // Hủy đạn sau một thời gian
            Destroy(gameObject, 2f);
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
        }
    }
}
