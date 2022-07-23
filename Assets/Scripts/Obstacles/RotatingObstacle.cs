using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingObstacle : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;

    private void FixedUpdate()
    {
        transform.Rotate(0,0,rotateSpeed);
    }
}
