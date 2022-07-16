using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private TriggerListener playerTriggerListener;
    [SerializeField] private AudioManager audioManager;
    
    private void OnEnable()
    {
        playerTriggerListener.OnEnter += OnTriggerEntered;
        playerTriggerListener.OnStay += OnTriggerStayed;
        playerTriggerListener.OnExit += OnTriggerExited;
    }

    private void OnDisable()
    {
        playerTriggerListener.OnEnter -= OnTriggerEntered;
        playerTriggerListener.OnStay -= OnTriggerStayed;
        playerTriggerListener.OnExit -= OnTriggerExited;
    }

    private void OnTriggerEntered(GameObject player, Collider2D gameObj)
    {
        gameObj.GetComponent<Collider2D>().enabled = false;
        if(gameObj.CompareTag("Obstacle"))
        {
            audioManager.PlayDeathSound();
        }
        else if(gameObj.CompareTag("Score"))
        {
            audioManager.PlayScoreSound();
        }
    }
    private void OnTriggerStayed(GameObject arg1, Collider2D arg2)
    {
        
    }
    private void OnTriggerExited(GameObject arg1, Collider2D arg2)
    {
        
    }


}
