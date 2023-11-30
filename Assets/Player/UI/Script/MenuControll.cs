using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControll : MonoBehaviour
{
    public GameObject h_PauseMenu;
    public GameObject h_Shop;
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
    
    public void OpenShop()
    {
        h_Shop.SetActive(true);
    }

    public void Immortal() {
        AudioManager.instance.Play("Button");
        GameObject gameObject = GameObject.FindGameObjectWithTag("Player01Animation");
        if (gameObject != null)
        {
            
            BoxCollider2D box= gameObject.GetComponent<BoxCollider2D>();
            if (box != null)
            {
                box.isTrigger = true;
            }
            
        }
        else
        {
            return;
        }
    }

    public void PlayerNotImmortal()
    {
        AudioManager.instance.Play("Button");
        GameObject gameObject = GameObject.FindGameObjectWithTag("Player01Animation");
        if (gameObject != null)
        {
            BoxCollider2D box = gameObject.GetComponent<BoxCollider2D>();
            if(box != null)
            {
                if(box.isTrigger == true)
                {
                    box.isTrigger= false;
                }
                else
                {
                    return;
                }
            }
        }
    }
}
