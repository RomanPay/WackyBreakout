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
    private int _speedIncrease = 1;
    private bool _ifSpeedup;
    private bool _addSpeed;
    
    #endregion

    void Start()
    {
        // Set timers
        SetTimers();
        
        // Save for efficiently
        _ballSpawner = Camera.main.GetComponent<BallSpawner>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        
        EventManager.AddSpeedupEffectListener(SetSpeedupEffect);
        _ifSpeedup = false;
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

        if (_ifSpeedup &&)
        {
            _rigidbody2D.velocity *= _speedIncrease * Time.deltaTime;
        }

        //
        if (_timerSpeedupEffect.Finished)
            _ifSpeedup = false;
    }

    private void SetSpeedupEffect(int speedUpTime, int speedIncrease)
    {
        Debug.Log("In set speed");
        _timerSpeedupEffect.Duration = speedUpTime;
        _speedIncrease = speedIncrease;
        _ifSpeedup = true;
        _addSpeed = true;
        _timerSpeedupEffect.Run();
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
