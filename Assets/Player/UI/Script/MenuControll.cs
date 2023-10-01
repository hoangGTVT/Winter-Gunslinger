using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControll : MonoBehaviour
{
    public GameObject h_PauseMenu;

    public void PauseGame()
    {
        Time.timeScale = 0f;
        h_PauseMenu.SetActive(true);
        AudioListener.pause = true;
    }
    public void RemuseGame() { 
        Time.timeScale = 1f;
        h_PauseMenu.SetActive(false);
        AudioListener.pause=false;
    }   
}
