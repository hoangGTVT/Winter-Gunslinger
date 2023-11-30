using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : FindObject
{
    [SerializeField] GameObject[] map;
    private void Start()
    {
        int countMap = PlayerPrefs.GetInt("Map");
        if (countMap < 1)
        {
            countMap = 0;
        }
        map[countMap].SetActive(true);
    }
}
