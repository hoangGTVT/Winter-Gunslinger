using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class Gold : MonoBehaviour
{
    public GameObject goldText;
    private void Update()
    {
        Destroy(gameObject,5);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision!=null && collision.gameObject.CompareTag("Player01Animation"))
        {
            PlayerLife playerLife =collision.gameObject.GetComponent<PlayerLife>();
            GameObject point = Instantiate(goldText, new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), quaternion.identity);
            point.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "+" + 20;

            playerLife.TakeGold(30);
            AudioManager.instance.Play("Item");
            Destroy(gameObject);
        }
    }
}
