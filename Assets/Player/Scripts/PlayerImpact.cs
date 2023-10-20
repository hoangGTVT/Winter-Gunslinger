using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerImpact : FindObject
{
    public PlayerLife playerLife;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Dead"))
        {
            playerLife.PlayerDead();

        }
        if (collision.gameObject.CompareTag("Enemy"))
        {

            playerLife.PlayerTakeDamage(playerLife.GetTotalHP() / 4);
        }

        


    }

   

}
