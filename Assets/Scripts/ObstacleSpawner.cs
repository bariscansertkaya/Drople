using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
   [SerializeField] GameObject obstacleGameobject;
   [SerializeField] float repeatRate;
   [SerializeField] Vector2 spawnPosition;


    void Start()
    {
        InvokeRepeating(nameof(SpawnObstacle),0,repeatRate);
    }

    void SpawnObstacle()
    {
        Instantiate(obstacleGameobject,spawnPosition,Quaternion.identity);
        spawnPosition=new Vector2(0,spawnPosition.y-30);
    }

}
