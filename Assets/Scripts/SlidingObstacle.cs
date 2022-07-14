using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingObstacle : MonoBehaviour
{
    SlidingObstacleMaster slidingObstacleMaster;

    [SerializeField] float maxX;
    [SerializeField] float minX;
    Rigidbody2D obstacleRigidbody;
    BoxCollider2D obstacleCollider;

        



    void Start()
    {
        TryGetComponent(out obstacleRigidbody);
        TryGetComponent(out obstacleCollider);
        slidingObstacleMaster=GetComponentInParent<SlidingObstacleMaster>();

    }


    void FixedUpdate()
    {
        if (transform.position.x<maxX)
        {
            obstacleRigidbody.velocity = new Vector2(slidingObstacleMaster.moveSpeed,0);
        }
        else 
        {
            transform.position = new Vector2(minX,transform.position.y);
        }
    }
}
