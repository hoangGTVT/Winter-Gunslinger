using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBoss1 : MonoBehaviour
{
    public GameObject blast;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player01Animation"))
        {
            PlayerLife playerLife = collision.gameObject.GetComponent<PlayerLife>();
            if (playerLife != null)
            {
                playerLife.PlayerTakeDamage(playerLife.GetTotalATK()-playerLife.GetLevel());
                
                Instantiate(blast, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            else
            {
                return;
            }
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            Instantiate(blast, new Vector3(transform.position.x,transform.position.y-1,transform.position.z) , Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
