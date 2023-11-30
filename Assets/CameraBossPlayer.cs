using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBossPlayer : MonoBehaviour
{
    private CinemachineTargetGroup targetGroup = null;
    void Start()
    {
        targetGroup = GetComponent<CinemachineTargetGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        Find();
    }

    private void Find()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player01Animation");
        GameObject boss = GameObject.FindGameObjectWithTag("Boss");
        if (player != null && boss!= null) {
            Transform playerTransform = player.transform;
            Transform bossTransform = boss.transform;

            // Tạo một danh sách các đối tượng để theo dõi trong targetGroup
            CinemachineTargetGroup.Target[] targets = new CinemachineTargetGroup.Target[2];
            targets[0].target = playerTransform;
            targets[0].weight = 1f; // Độ ưu tiên cho player (có thể thay đổi)
            targets[1].target = bossTransform;
            targets[1].weight = 1f; // Độ ưu tiên cho boss (có thể thay đổi)

            // Đặt các đối tượng trong targetGroup
            targetGroup.m_Targets = targets;

            // Kích hoạt targetGroup
           
        }
    }
}
