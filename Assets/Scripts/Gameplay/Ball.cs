using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Events;


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

    private Timer _timerSpeedupEffect;
    private float _speedIncrease;
    
    #endregion

    void Start()
    {
        // Set timers
        SetTimers();
        
        // Save for efficiently
        _ballSpawner = Camera.main.GetComponent<BallSpawner>();
        
        // Speedup effect support
        _rigidbody2D = GetComponent<Rigidbody2D>();
        EventManager.AddSpeedupEffectListener(SetSpeedupEffect);
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
        
        // Timer for speedup effect
        _timerSpeedupEffect = gameObject.AddComponent<Timer>();
    }
    
    /// <summary>
    /// Set directions after hit paddle
    /// </summary>
    /// <param name="direction">direction</param>
    public void SetDirection(Vector2 direction)
    {
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
        float speed = rigidbody2D.velocity.magnitude;
        rigidbody2D.velocity = direction * speed;
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
        
        if (_timerSpeedupEffect.Finished)
        {
            _timerSpeedupEffect.Stop();
            _rigidbody2D.velocity *= 1 / _speedIncrease;
        }
    }

    private void SetSpeedupEffect(int speedUpTime, int speedIncrease)
    {
        if (!_timerSpeedupEffect.Running)
        {
            StartSpeedupEffect(speedUpTime, speedIncrease);
            _rigidbody2D.velocity *= speedIncrease;
        }
        else
            _timerSpeedupEffect.AddTime(speedUpTime);
    }

    private void StartSpeedupEffect(float duration, int speedupFactor)
    {
        _speedIncrease = speedupFactor;
        _timerSpeedupEffect.Duration = duration;
        _timerSpeedupEffect.Run();
    }
    
    /// <summary>
    /// Moving new ball down
    /// </summary>
    private void StartMoving()
    {
        if (_rigidbody2D.velocity.magnitude > 0)
            return;
        float angle = -90 * Mathf.Deg2Rad;
        Vector2 force = new Vector2(
                                ConfigurationUtils.BallImpulseForce * Mathf.Cos(angle),
                                ConfigurationUtils.BallImpulseForce * Mathf.Sin(angle));
        if (EffectUtils.SpeedupEffectActive)
        {
            StartSpeedupEffect(EffectUtils.TimerLeft, EffectUtils.SpeedupFactor);
            force *= _speedIncrease;
        }
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
