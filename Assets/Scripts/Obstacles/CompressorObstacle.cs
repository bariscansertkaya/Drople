using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CompressorObstacle : MonoBehaviour
{
    [SerializeField] private float endValue;
    [SerializeField] private float duration;
    private void Start()
    {
        transform.DOMoveX(endValue, duration).SetLoops(-1,LoopType.Yoyo).SetEase(Ease.OutExpo);
    }
}
