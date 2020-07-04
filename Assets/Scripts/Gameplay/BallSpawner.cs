using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// A spawn balls
/// </summary>
public class BallSpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefabBall;

    private Timer _timerRandomSpawn;

    private bool _retrySpawn = false;
    private Vector2 _spawnLocationMin;
    private Vector2 _spawnLocationMax;
    private void Start()
    {
        GameObject tempBall = Instantiate(prefabBall);
        float ballColliderRadius = tempBall.GetComponent<CircleCollider2D>().radius;
        var position = tempBall.transform.position;
        _spawnLocationMin = new Vector2(position.x,
            position.y - ballColliderRadius);
        _spawnLocationMax = new Vector2(position.x, 
            position.y + ballColliderRadius);
        Destroy(tempBall);
        
        _timerRandomSpawn = gameObject.AddComponent<Timer>();
        _timerRandomSpawn.Duration = Random.Range(ConfigurationUtils.MinSpawnTime, ConfigurationUtils.MaxSpawnTime);
        _timerRandomSpawn.Run();
    }

    /// <summary>
    /// Spawn ball
    /// </summary>
    public void SpawnBall()
    {
        if (Physics2D.OverlapArea(_spawnLocationMin, _spawnLocationMax) == null)
        {
            _retrySpawn = false;
            Instantiate(prefabBall);
        }
        else
        {
            _retrySpawn = true;
        }
    }

    private void Update()
    {
        if (_timerRandomSpawn.Finished || _retrySpawn)
        {
            SpawnBall();
            _timerRandomSpawn.Duration = Random.Range(ConfigurationUtils.MinSpawnTime, ConfigurationUtils.MaxSpawnTime);
            _timerRandomSpawn.Run();
        }
    }
}
