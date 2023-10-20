using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hppoint : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject,5);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null && collision.gameObject.CompareTag("Player01Animation"))
        {
            PlayerLife playerLife=collision.gameObject.GetComponent<PlayerLife>();
            playerLife.PlusHPPoint();
            AudioManager.instance.Play("Item");
            Destroy(gameObject);
        }
    }
}
