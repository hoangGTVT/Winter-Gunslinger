using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject[] item;
    private BoxCollider2D boxCollider;
    private Animator animator;
    public bool h_ItemSpawn = false;
    public bool h_ItemSpawn1 = false;
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player01Animation"))
        {
            animator.SetBool("IsOpen",true);
            boxCollider.isTrigger = true;
            
           
        }
    }

    public void CreateItem()
    {
        
        //Instantiate(item[0],vector,Quaternion.identity);
        Instantiate(item[1], transform.position, Quaternion.identity);
            
        
        float drop = 0.8f;
        int randomNumber = Random.Range(0, 2);
        if (Random.value <= drop)
        {
            if (randomNumber == 0 )
            {

                Instantiate(item[2], transform.position, Quaternion.identity);
                

            }
            else if (randomNumber == 1 )
            {

                Instantiate(item[3], transform.position, Quaternion.identity);
                
            }

        }
    }
}
