using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map31 : MonoBehaviour
{
    public GameObject[] objectToSpawn; // Tham chiếu đối tượng bạn muốn sao chép
    public float spacing = 3.0f; // Khoảng cách giữa các đối tượng
    [SerializeField] public float currentX = 1.0f; // Vị trí X ban đầu
    [SerializeField] public float current1X = 12.0f;

    void Start()
    {
        SpawnPoint();
        SpawnPoint1();
    }

    public void SpawnPoint()
    {
        Vector3 spawnPosition = new Vector3(currentX, -2, 0); // Đặt vị trí ban đầu

        for (int i = 0; i < 5; i++)
        {
            Instantiate(objectToSpawn[0], spawnPosition, Quaternion.identity); // Tạo một bản sao của đối tượng và đặt vị trí

            currentX += spacing; // Cập nhật vị trí X cho đối tượng tiếp theo
            spawnPosition.x = currentX;
        }
    }

    public void SpawnPoint1()
    {
        Vector3 spawnPosition = new Vector3(current1X, 2, 0); // Đặt vị trí ban đầu

        for (int i = 0; i < 4; i++)
        {
            Instantiate(objectToSpawn[1], spawnPosition, Quaternion.identity); // Tạo một bản sao của đối tượng và đặt vị trí

            current1X += 4f;
            spawnPosition.x = current1X;
        }
    }
}
