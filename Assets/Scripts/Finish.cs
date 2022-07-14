using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject winCanvas;
    [SerializeField] private Transform trophy;
    [SerializeField] private CinemachineVirtualCamera followCam;
    [SerializeField] private Player player;
    [SerializeField] private ParticleSystem winEffect;
    [SerializeField] private AudioManager audioManager; 

    private void OnTriggerEnter2D(Collider2D col)
    {
        FinishGame();
    }

    private void FinishGame()
    {
        audioManager.PlayWinSound();
        winEffect.Play();
        winCanvas.SetActive(true);
        followCam.GetCinemachineComponent<CinemachineFramingTransposer>().m_TrackedObjectOffset = new Vector3(0, 10, 0);
        followCam.Follow = trophy;
        
        
        player.DisablePlayer();
    }
}
