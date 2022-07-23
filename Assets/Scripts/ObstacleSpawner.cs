using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> obstacles;
    [SerializeField] private int poolCount;
    [SerializeField] private float timeBetweenSpawns;
    [SerializeField] private float spawnY;
    [SerializeField] private float distanceBetweenObstacles;

    private List<GameObject> _pooledObstacles;
    private float _elapsedTime;
    

    private void Start()
    {
        _pooledObstacles = new List<GameObject>();
        
        for (int i = 0; i < poolCount; i++)
        {
            GameObject obj = Instantiate(obstacles[Random.Range(0,obstacles.Count)]);
            obj.SetActive(false);
            _pooledObstacles.Add(obj);
            
        }
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if(_elapsedTime>=timeBetweenSpawns)
        {
            SpawnObstacle();
            _elapsedTime = 0;
        }
    }

    private void SpawnObstacle()
    {
        foreach (var obstacle in _pooledObstacles)
        {
            if(!obstacle.activeInHierarchy)
            {
                obstacle.transform.position = new Vector2(0, spawnY);
                spawnY -= distanceBetweenObstacles;
                obstacle.SetActive(true);
            }
        }
    }
}
