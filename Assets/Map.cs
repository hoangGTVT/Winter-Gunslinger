using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public GameObject player;
    public GameObject loadingMap;
    public float pointX;
    public float pointY;
    void Start()
    {
        loadingMap.SetActive(true);
        Instantiate(player,new Vector2(pointX,pointY),Quaternion.identity);
        PauseGame();
        PlayerPrefs.DeleteKey("Key");
    }

    // Update is called once per frame
    void Update()
    {
        if (Loading.h_Percent >= 100)
        {
            Loading.h_Percent = 0;
            loadingMap.SetActive(false);
            RemuseGame();
        }

        
        
            
        
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
       
        AudioListener.pause = true;
    }
    public void RemuseGame()
    {
        Time.timeScale = 1f;
        
        AudioListener.pause = false;
    }
}
