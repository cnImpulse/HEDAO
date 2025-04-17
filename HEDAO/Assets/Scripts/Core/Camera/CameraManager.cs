using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : BaseManager
{
    public CinemachineVirtualCamera VirtualCamera;
    
    protected override void OnInit()
    {
        VirtualCamera = Camera.main.GetComponent<CinemachineBrain>().ActiveVirtualCamera as CinemachineVirtualCamera;
    }
}
