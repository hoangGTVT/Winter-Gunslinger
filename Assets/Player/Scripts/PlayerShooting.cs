using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    PlayerControls controls;
    

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Filp()
    {
        transform.Rotate(0, 180, 0);  
    }
}
