using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;


/// <summary>
/// A ball
/// </summary>
public class Ball : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Timer _timerLifetime;
    private Timer _timerForNewBall;
    private BallSpawner _ballSpawner;
    private bool _ifTimeFinish;

    private HUD _hud;

    void Start()
    {
        SetTimers();

        _ballSpawner = Camera.main.GetComponent<BallSpawner>();
        
        _rigidbody2D = GetComponent<Rigidbody2D>();
        
        _hud = GameObject.FindWithTag("HUD").GetComponent<HUD>();
        
    }

    /// <summary>
    /// Set timers for control balls lifetime
    /// </summary>
    private void SetTimers()
    {
        // Timer for lifetime
        _timerLifetime = gameObject.AddComponent<Timer>();
        _timerLifetime.Duration = ConfigurationUtils.BallLifetime;
        _timerLifetime.Run();
        
        // Timer for start moving new ball
        _timerForNewBall = gameObject.AddComponent<Timer>();
        _timerForNewBall.Duration = 1f;
        _timerForNewBall.Run();
        
        // Flag for check if timer above finished
        // for prevent adding force to the ball every frame
        _ifTimeFinish = false;
    }
    
    /// <summary>
    /// Set directions after hit paddle
    /// </summary>
    /// <param name="direction">direction</param>
    public void SetDirection(Vector2 direction)
    {
        _rigidbody2D.velocity = direction * (Time.deltaTime * ConfigurationUtils.BallImpulseForce);
    }
    
    void Update()
    {
        if (_timerLifetime.Finished)
            DestroyAndSpawn();

        if (gameObject.transform.position.y < ScreenUtils.ScreenBottom)
        {
            _hud.IncreaseBalls();
            DestroyAndSpawn();
        }
        
        if (_timerForNewBall.Finished && !_ifTimeFinish)
            StartMoving();
    }

    /// <summary>
    /// Moving new ball down
    /// </summary>
    private void StartMoving()
    {
        float angle = 270f * (Mathf.PI / 180);
        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        _rigidbody2D.AddForce(direction * (Time.deltaTime * ConfigurationUtils.BallImpulseForce), 
            ForceMode2D.Impulse);
        _ifTimeFinish = true;
    }

    private void DestroyAndSpawn()
    {
        Destroy(gameObject);
        _ballSpawner.SpawnBall();
    }
}
