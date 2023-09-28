using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waepon : MonoBehaviour
{
    public Transform h_ShootingPoint;
    public GameObject[] h_Bullet;
   

    private int h_BulletCount;
   
    private void Start()
    {
        h_BulletCount = 2;
    }

    void Update()
    {
       
    }

    public void Shoot()
    {
        // Gọi hàm CreateBullet() sau 1 giây
        Invoke("CreateBullet", 0.25f);
    }

    private void CreateBullet()

    {
        AudioManager.instance.Play("Bullet");
        GameObject bullet = Instantiate(h_Bullet[h_BulletCount], h_ShootingPoint.position, h_ShootingPoint.rotation);
    }


}
