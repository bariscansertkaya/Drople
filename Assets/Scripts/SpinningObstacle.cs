using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningObstacle : MonoBehaviour
{

    [SerializeField] float  rotationSpeed;
    Vector3 rotationVector;
    void Start()
    {
        rotationVector=new Vector3(0,0,rotationSpeed);
    }
    void FixedUpdate()
    {
        transform.Rotate(rotationVector);
    }
}
