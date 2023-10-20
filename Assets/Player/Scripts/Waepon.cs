using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waepon : MonoBehaviour
{
    public Transform h_ShootingPoint;
    public GameObject[] h_Bullet;


    [SerializeField] private int h_BulletCount;
    private void Awake()
    {
        if (PlayerPrefs.GetInt("Bullet") == 0)
        {
            h_BulletCount = 0;
            
        }
        else
        {
            h_BulletCount = PlayerPrefs.GetInt("Bullet");
        }
    }

    

    public void Shoot()
    {
        
        //Invoke("CreateBullet", 0.1f);
        CreateBullet();
    }

    private void CreateBullet()

    {
        AudioManager.instance.Play("Bullet");
        var bullet = Instantiate(h_Bullet[h_BulletCount], h_ShootingPoint.position, h_ShootingPoint.rotation);
        
    }

    public void SetBullet(int h)
    {
        h_BulletCount = h;
        PlayerPrefs.SetInt("Bullet", h);
    }


}
