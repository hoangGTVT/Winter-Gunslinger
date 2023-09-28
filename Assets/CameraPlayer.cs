using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : FindObject
{
    private CinemachineVirtualCamera virtualCamera;
    // Start is called before the first frame update
    void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        FollowPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer(); 
    }
    public void FollowPlayer()
    {
        GameObject playerObject = base.FindObjectWithTag("Player01Animation");
        if (playerObject != null)
        {
            virtualCamera.Follow = playerObject.transform;
            virtualCamera.LookAt = playerObject.transform;
        }
       
    }
}
