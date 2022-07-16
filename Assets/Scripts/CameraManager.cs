using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

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
        if(Camera.main != null) followCam.m_Lens.OrthographicSize = Camera.main.orthographicSize;
        followCam.enabled=true;
        resolutionCam.enabled=false;
    }
}
