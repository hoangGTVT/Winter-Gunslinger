using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEditor.AnimatedValues;
using UnityEngine;

public class Dead : FindObject
{
    public PlayerLife playerLife;
    public GameObject h_Player;
    public Vector3 vt=new Vector3(0,0,0);
    private void Start()
    {
        
    }
    // Start is called before the first frame update
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player01"))
        {
          
            playerLife.PlayerDead();
        }
    }*/

    private void Update()
    {
        playerLife = base.FindObjectsToGetComponent("Player01",playerLife);
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (playerLife == null)
            {
                Instantiate(h_Player, vt, Quaternion.identity);
            }
           

        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            playerLife.PlayerDead();




        }

    }
}
