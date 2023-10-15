using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision!=null && collision.gameObject.CompareTag("Player01Animation"))
        {
            PlayerLife playerLife =collision.gameObject.GetComponent<PlayerLife>();
            playerLife.TakeGold(50);
            AudioManager.instance.Play("Item");
            Destroy(gameObject);
        }
    }
}
