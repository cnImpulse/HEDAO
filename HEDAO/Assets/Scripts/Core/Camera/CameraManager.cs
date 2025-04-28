using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : BaseManager
{
    public CinemachineVirtualCamera VirtualCamera;
    public CinemachineBrain Brain;

    protected override void OnInit()
    {
        Brain = Camera.main.GetComponent<CinemachineBrain>();
        VirtualCamera = Brain.ActiveVirtualCamera as CinemachineVirtualCamera;
    }
}
