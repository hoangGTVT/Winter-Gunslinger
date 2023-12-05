using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextMap : MonoBehaviour
{
    [SerializeField] private GameObject[] map;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision != null && collision.gameObject.CompareTag("Player01Animation"))
        {
            GameObject gameObject1 = GameObject.FindGameObjectWithTag("Player01");
            if(gameObject1 != null) {
                Destroy(gameObject1);
            }
            if (PlayerPrefs.GetInt("Map") < 4)
            {
                PlayerPrefs.SetInt("Map", PlayerPrefs.GetInt("Map") + 2);
            }else if (PlayerPrefs.GetInt("Map") >= 4)
            {
                PlayerPrefs.SetInt("Map", PlayerPrefs.GetInt("Map") + 1);
            }



                int kMap = PlayerPrefs.GetInt("KMap");
            if(kMap < 1) { 
                kMap = 0;
                kMap += 1;
            }
            else
            {
                kMap += 1;
            }
           
            PlayerPrefs.SetInt("KMap", kMap);
            map[0].SetActive(false);
            map[1].SetActive(true);
            
            

        }
    }
}
