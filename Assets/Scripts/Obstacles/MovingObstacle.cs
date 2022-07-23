using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;

    [SerializeField] private float moveSpeed;

    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        TryGetComponent(out _rigidbody2D);
    }

    private void Update()
    {
        
    }


}
