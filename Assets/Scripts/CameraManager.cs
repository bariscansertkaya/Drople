using System;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera resolutionCam;
    [SerializeField] CinemachineVirtualCamera followCam;
    [SerializeField] float delayTime;

    void Start()
    {
        Invoke(nameof(SetFollowCamera),delayTime);
    }

    void SetFollowCamera()
    {
        followCam.m_Lens.OrthographicSize=Camera.main.orthographicSize;
        followCam.enabled=true;
        resolutionCam.enabled=false;
    }

}
