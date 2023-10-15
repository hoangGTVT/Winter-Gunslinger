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

    public void Awake()
    {

        PlayerPrefs.DeleteKey("NamePlayer");
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
}
