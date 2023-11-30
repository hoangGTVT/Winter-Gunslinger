using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointLife : MonoBehaviour
{
    public int hP = 10;
    public static bool h_Eff = false;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(hP<1)
        {
            Destroy(gameObject);
            h_Eff = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            hP -= 1;
        }
    }

    
}
