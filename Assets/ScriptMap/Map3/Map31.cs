using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map31 : MonoBehaviour
{
    public GameObject objectToSpawn; // Tham chiếu đối tượng bạn muốn sao chép
    public float spacing = 3.0f; // Khoảng cách giữa các đối tượng
    private float currentX = 1.0f; // Vị trí X ban đầu

    void Start()
    {
        Vector3 spawnPosition = new Vector3(currentX, -2, 0); // Đặt vị trí ban đầu

        for (int i = 0; i < 5; i++)
        {
            Instantiate(objectToSpawn, spawnPosition, Quaternion.identity); // Tạo một bản sao của đối tượng và đặt vị trí

            currentX += spacing; // Cập nhật vị trí X cho đối tượng tiếp theo
            spawnPosition.x = currentX;
        }
    }
}
