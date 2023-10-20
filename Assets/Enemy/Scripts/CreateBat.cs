using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBat : MonoBehaviour
{
   public GameObject bat;
   

   
    void Start()
    {
        InvokeRepeating("SpawnBat", 0, 10.5f);
    }
    

    
    void Update()
    {
 
    }

    public void SpawnBat()
    {
        Instantiate(bat, transform.position, Quaternion.identity);
    }
}
