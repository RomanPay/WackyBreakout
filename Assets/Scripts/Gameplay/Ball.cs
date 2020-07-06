using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;


/// <summary>
/// A ball
/// </summary>
public class Ball : MonoBehaviour
{
    #region Fields

    // Move delay timer
    private Timer _timerMove;

    // Death timer
    private Timer _timerDeath;

    private Rigidbody2D _rigidbody2D;
    private BallSpawner _ballSpawner;

    #endregion

    void Start()
    {
        // Set timers
        SetTimers();
        
        // Save for efficiently
        _ballSpawner = Camera.main.GetComponent<BallSpawner>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Set timers for control balls lifetime
    /// </summary>
    private void SetTimers()
    {
        // Timer for lifetime
        _timerDeath = gameObject.AddComponent<Timer>();
        _timerDeath.Duration = ConfigurationUtils.BallLifetime;
        _timerDeath.Run();
        
        // Timer for start moving new ball
        _timerMove = gameObject.AddComponent<Timer>();
        _timerMove.Duration = 1f;
        _timerMove.Run();
    }
    
    /// <summary>
    /// Set directions after hit paddle
    /// </summary>
    /// <param name="direction">direction</param>
    public void SetDirection(Vector2 direction)
    {
        float speed = _rigidbody2D.velocity.magnitude;
        _rigidbody2D.velocity = direction * speed;
    }
    
    void Update()
    {
        if (_timerDeath.Finished)
            DestroyAndSpawn();

        if (gameObject.transform.position.y < ScreenUtils.ScreenBottom)
        {
            HUD.DecreaseBalls();
            DestroyAndSpawn();
        }

        if (_timerMove.Finished)
        {
            _timerMove.Stop();
            StartMoving();
        }
    }

    /// <summary>
    /// Moving new ball down
    /// </summary>
    private void StartMoving()
    {
        float angle = 270f * (Mathf.PI / 180);
        Vector2 force = new Vector2(ConfigurationUtils.BallImpulseForce * Mathf.Cos(angle),
            ConfigurationUtils.BallImpulseForce * Mathf.Sin(angle));
        _rigidbody2D.AddForce(force);
    }

    /// <summary>
    /// Destroys current ball and spawns new
    /// </summary>
    private void DestroyAndSpawn()
    {
        Destroy(gameObject);
        _ballSpawner.SpawnBall();
    }
}
