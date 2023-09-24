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
        Destroy(gameObject, 1);
    }

    // Update is called once per frame
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Boss"))
        {
            Instantiate(h_Blast, transform.position, Quaternion.identity);
            Destroy(gameObject);
            
        }
    }
}
