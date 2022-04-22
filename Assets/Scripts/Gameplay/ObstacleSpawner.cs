using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : SingletonMonoBehaviour<ObstacleSpawner>
{
    [Header("Obstacle Pool")]
    [SerializeField] private Pool obstaclePool;
    [Header("Spawn Position")]
    [SerializeField] private Vector2 spawnPosition;
    [SerializeField] private float endPositionX;
    [Header("Spawn Duration")]
    [SerializeField] private float spawnDelayDuration;
    [SerializeField] private float spawnRepeatDuration;
    [Header("Obstacle Movement")]
    [SerializeField] private float obstacleMovementSpeed;
    private bool canSpawn;

    protected override void Awake()
    {
        base.Awake();
        InvokeRepeating("SpawnObstacle", spawnDelayDuration, spawnRepeatDuration);
    }
    private void Update() => MoveObstacles();
    public void StartSpawning() => canSpawn = true;
    public void StopSpawning() => canSpawn = false;
    private void SpawnObstacle()
    {
        if (!canSpawn) return;
        GameObject obstacle = obstaclePool.GetRandomItem;
        obstacle.transform.position = spawnPosition;
        obstacle.SetActive(true);
    }
    private void MoveObstacles()
    {
        GameObject[] items = obstaclePool.GetActiveItems;
        for (int i = 0; i < items.Length; i++) 
        { 
            items[i].transform.position -= items[i].transform.right * obstacleMovementSpeed * Time.deltaTime;
            if (items[i].transform.position.x < endPositionX) items[i].SetActive(false);
        }
    }
}
