using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource explosion;
    [SerializeField] AudioSource score;
    [SerializeField] AudioSource death;
    [SerializeField] AudioSource win;
    

    /*public void PlaySpeedUpSound()
    {
        speedUp.Play();
    }

    public void StopSpeedUpSound()
    {
        speedUp.Stop();
    }*/

    public void PlayExplosionSound()
    {
        explosion.Play();
    }

    public void PlayScoreSound()
    {
        score.Play();
    }

    public void PlayDeathSound()
    {
        death.Play();
    }

    public void PlayWinSound()
    {
        win.Play();
    }
    





}
