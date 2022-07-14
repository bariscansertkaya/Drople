using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.InputSystem;
using System;
using Cinemachine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    [SerializeField] GameOverHandler gameOverHandler;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI gameOverScoreText;
    [SerializeField] float fastSpeed;
    [SerializeField] float slowSpeed;
    [SerializeField] float speedBoost;
    [SerializeField] float powerHitCharge;
    [SerializeField] float speedChangeRate;
    [SerializeField] Slider powerSlider;

    [SerializeField] Animator cameraAnimator;

    [SerializeField] GameObject blockEffect;
    [SerializeField] GameObject playerEffect;
    [SerializeField] GameObject tutorialMenu;

    [SerializeField] ParticleSystem powerHitEffect;

    AudioManager audioManager;
    Rigidbody2D playerRigidbody;
    CapsuleCollider2D playerCollider;
    SpriteRenderer playerSpriteRenderer;

    TrailRenderer playerTrailRenderer;



    int score=50;
    float powerHitCounter;

    bool powerHitActive;
    //bool powerUpSoundPlaying;
    bool isAlive=true;
    private static readonly int Shake = Animator.StringToHash("Shake");

    void Awake()
    {
        TryGetComponent(out playerRigidbody);
        TryGetComponent(out playerCollider);
        TryGetComponent(out playerSpriteRenderer);
        TryGetComponent(out playerTrailRenderer);
        TryGetComponent(out audioManager);
    }

    void Start()
    {
        powerSlider.maxValue=powerHitCharge;
        scoreText.text="LOWEST: "+ PlayerPrefs.GetInt("LowScore");
        Invoke("DisableTutorial", 3);
    }


    void Update()
    {
        if (!isAlive&&slowSpeed>.6f)
        {
            slowSpeed -= speedChangeRate * Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        IncreasePlayerSpeed();
    }
    public void ClearPlayerHighScore()
    {
        PlayerPrefs.SetInt("LowScore",50);
    }
    void IncreasePlayerSpeed() 
    {
        if (Touchscreen.current.primaryTouch.press.IsPressed()&&isAlive)
        {
            Invoke("DisableTutorial", .5f);
            powerHitCounter +=Time.deltaTime;
            powerSlider.value=powerHitCounter;

            /*if(!powerUpSoundPlaying){audioManager.PlaySpeedUpSound();}
            powerUpSoundPlaying=true;*/

            if (powerHitCounter>powerHitCharge)
            {
                powerHitActive=true;
                powerHitEffect.Play();
            }else
            {
                powerHitActive=false;
                powerHitEffect.Stop();
            }
            playerRigidbody.velocity = new Vector2(0f, -fastSpeed);
        }
        else 
        {

            powerHitCounter=0;
            powerSlider.value=0;
            powerHitActive=false;
            powerHitEffect.Stop();
            //powerUpSoundPlaying=false;
            //audioManager.StopSpeedUpSound(); 
            playerRigidbody.velocity = new Vector2(0f, -slowSpeed);
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {

        if (other.CompareTag("Obstacle")&&!powerHitActive)
        {
            Destroy(other.gameObject);
            audioManager.PlayDeathSound();
            Instantiate(playerEffect, transform.position, Quaternion.identity);
            Instantiate(blockEffect, transform.position, Quaternion.identity);
            cameraAnimator.SetTrigger("Death");
            DisablePlayer();
            gameOverHandler.EnableGameOverScreen();

        }
        else if (other.CompareTag("Obstacle")&&powerHitActive)
        {
            Destroy(other.gameObject);
            if (Touchscreen.current.primaryTouch.press.IsPressed())
            {
                //powerUpSoundPlaying=false;
            }
            audioManager.PlayExplosionSound();
            cameraAnimator.SetTrigger(Shake);
            Instantiate(blockEffect,other.transform.position,Quaternion.identity);
            powerHitCounter=0;
        }
        else if(other.CompareTag("Score"))
        {
            Destroy(other.gameObject);
            score--;
            scoreText.text=score.ToString();
            audioManager.PlayScoreSound();
            gameOverScoreText.text="Obstacles left: "+score.ToString();

            if (score<PlayerPrefs.GetInt("LowScore"))
            {
                PlayerPrefs.SetInt("LowScore", score);
            }
        }
    }

    public void DisablePlayer()
    {
        playerSpriteRenderer.enabled = false;
        playerTrailRenderer.emitting = false;
        playerCollider.enabled = false;
        isAlive = false;
    }

    public void EnablePlayer() 
    {
        playerSpriteRenderer.enabled = true;
        playerTrailRenderer.emitting = true;
        playerCollider.enabled = true;
        isAlive = true;
        slowSpeed = 8;
    }

    

    private void DisableTutorial() 
    {
        tutorialMenu.SetActive(false);
    }

}
