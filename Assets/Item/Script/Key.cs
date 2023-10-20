using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    // Start is called before the first frame update
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
            AudioManager.instance.Play("Item");
            playerLife.PlusKey();
            Destroy(gameObject);
        }
        
    }
}
