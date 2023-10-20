using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class FireDragon : MonoBehaviour
{
    [SerializeField] protected int h_BulletSpeed = 3;
    public float h_PlusDamege;

    private SpriteRenderer sprite;
    [SerializeField] public int h_dame = 30;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        FindPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject,0.3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player01Animation"))
        {
            PlayerLife playerLife= collision.gameObject.GetComponent<PlayerLife>();
            playerLife.PlayerTakeDamage(playerLife.GetTotalATK() + h_dame);
            
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
            
        }
        else
        {
            return;
        }
    }
}
