using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public static float speed = 10f;
    public Rigidbody2D rb;
    public GameObject h_Blast;

    void Start()
    {
        
        rb.velocity=transform.right*speed;
        
    }
    private void Update()
    {
        Destroy(gameObject, 0.5f);


    }

    // Update is called once per frame
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Boss") || other.gameObject.CompareTag("Enemy")|| other.gameObject.CompareTag("PointLife"))
        {

            DestroyBullet();


        }
    }



    public void DestroyBullet()
    {
        Instantiate(h_Blast, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
