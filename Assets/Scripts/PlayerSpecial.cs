using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpecial : MonoBehaviour
{

    [SerializeField] private float specialChargeTime;
    [SerializeField] private ParticleSystem specialParticle;
    

    private float _specialTimer;
    
    private void Update()
    {
        if (Touchscreen.current.primaryTouch.press.IsPressed())
        {
            _specialTimer += Time.deltaTime;

            if(_specialTimer >= specialChargeTime)
            {
                EnableSpecial();
            }
            else
            {
                DisableSpecial();
            }
        }
        else
        {
            _specialTimer = 0;
            DisableSpecial();
        }
    }
    
    private void EnableSpecial()
    {
        specialParticle.Play();
    }
    private void DisableSpecial()
    {
        specialParticle.Stop();
    }

    public float GetSpecialTimer()
    {
        return _specialTimer;
    }
}
