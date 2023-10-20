using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Box : MonoBehaviour
{
    public Dragon dragon;
    public static bool h_IsRun;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("LLL");
            h_IsRun = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            h_IsRun = false;
            Debug.Log("CCC");
            /* GameObject gameObject1 = GameObject.FindGameObjectWithTag("Dragon");
             Dragon dragon= gameObject.GetComponent<Dragon>();
             if (gameObject1 != null)
             {
                 Animator animator = gameObject1.GetComponent<Animator>();
                 animator.SetInteger("State", 0);
             }*/


        }
    }


    public bool IsRun()
    {
        return h_IsRun;
    }
}
