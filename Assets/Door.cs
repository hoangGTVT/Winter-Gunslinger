using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    public GameObject doorPrefab;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null && collision.gameObject.CompareTag("Player01Animation"))
        {
            PlayerLife playerLife=  collision.gameObject.GetComponent<PlayerLife>();
            if (playerLife != null)
            {
                if (playerLife.GetKey() == 5)
                {
                    Destroy(gameObject);
                }
                else
                {
                    doorPrefab.SetActive(true);
                }
            }
        }
    }
}
