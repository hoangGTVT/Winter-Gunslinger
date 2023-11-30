using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseBullet : MonoBehaviour
{
    public int index;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player01Animation"))
        {
            
            PlayerPrefs.SetFloat("ChooseBullet", index);
            AudioManager.instance.Play("Item");
            Destroy(gameObject);
        }
    }
}
