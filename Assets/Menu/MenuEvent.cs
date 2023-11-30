using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuEvent : MonoBehaviour
{
    public GameObject[] gameObjects;
    public TMP_InputField inputField;
    [SerializeField] protected string h_NamePlayer;
    public GameObject[] gameObjects1;
    public void Awake()
    {

        //PlayerPrefs.DeleteAll();
    }
    public void LoadSence()
    {
        SceneManager.LoadScene("Game");
    }

    public void CheckName()
    {
        if (PlayerPrefs.GetString("NamePlayer") == "")
        {
            gameObjects[0].SetActive(true);
        }
        else
        {
            LoadSence();  
        }
    }

    public void SetName()
    {
        h_NamePlayer = inputField.text;
        if (h_NamePlayer.Length > 10)
        {
            gameObjects[1].SetActive(true);
        }
        else
        {
            PlayerPrefs.SetString("NamePlayer", h_NamePlayer);
            LoadSence();
        }
        

    }

    public void ChooseMap1()
    {
        PlayerPrefs.SetInt("Map", 0);
        gameObjects1[1].SetActive(true);
    }
    public void ChooseMap2()
    {
        if (PlayerPrefs.GetInt("KMap") >= 1)
        {
            PlayerPrefs.SetInt("Map", 1);
            gameObjects1[1].SetActive(true);
        }
        else
        {
            gameObjects1[0].SetActive(true);
        }
        
    }
    public void ChooseMap3()
    {
        if (PlayerPrefs.GetInt("KMap") >= 1)
        {
            PlayerPrefs.SetInt("Map", 2);
            gameObjects1[1].SetActive(true);
        }
        else
        {
            gameObjects1[0].SetActive(true);
        }
       
    }
    public void ChooseMap4()
    {
        if (PlayerPrefs.GetInt("KMap") >= 2)
        {
            PlayerPrefs.SetInt("Map", 3);
            gameObjects1[1].SetActive(true);
        }
        else
        {
            gameObjects1[0].SetActive(true);
        }
    }
    public void ChooseMap5()
    {
        if (PlayerPrefs.GetInt("KMap") >= 2)
        {
            PlayerPrefs.SetInt("Map", 4);
            gameObjects1[1].SetActive(true);
        }
        else
        {
            gameObjects1[0].SetActive(true);
        }
    }
    public void ChooseMap6()
    {
        if (PlayerPrefs.GetInt("KMap") > 2)
        {
            PlayerPrefs.SetInt("Map", 5);
            gameObjects1[1].SetActive(true);
        }
        else
        {
            gameObjects1[0].SetActive(true);
        }
        
    }
}
