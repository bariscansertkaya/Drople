using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class GamePanel : MonoBehaviour
{
    [SerializeField] private PlayerSpecial playerSpecial;
    [SerializeField] private GameOverManager gameOverManager;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Slider specialSlider;
    private void Update()
    {
        specialSlider.value = playerSpecial.GetSpecialTimer();
        scoreText.text = gameOverManager.GetScore();
    }
}
