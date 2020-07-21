using System;
using UnityEngine;

/// <summary>
/// Keep timer for speedup effect
/// </summary>
public class SpeedupEffectMonitor : MonoBehaviour
{
    private Timer _timer;
    private int _speedupFactor;

    private void Start()
    {
        EventManager.AddSpeedupEffectListener(KeepTrackOfTime);
        _timer = gameObject.AddComponent<Timer>();
    }

    /// <summary>
    /// Gets if running speedup effect
    /// </summary>
    /// <value><c>true</c> if speedup effect active; otherwise, <c>false</c>.</value>
    public bool SpeedupEffectActive => _timer.Running;

    /// <summary>
    /// Gets speedup factor to increase speed balls 
    /// </summary>
    /// <value>speedup factor</value>
    public int SpeedupFactor => _speedupFactor;

    /// <summary>
    /// Gets time to finish current timer keep of track speedup effect
    /// </summary>
    /// <value>time to finish</value>
    public float TimeToFinish => _timer.Left;

    /// <summary>
    /// Sets and prolong running timer for speedup factor
    /// </summary>
    /// <param name="duration">duration</param>
    /// <param name="speed">speed</param>
    void KeepTrackOfTime(int duration, int speed)
    {

        if (!_timer.Running)
        {
            _speedupFactor = speed;
            _timer.Duration = duration;
            _timer.Run();
        }
        else
        {
            _timer.AddTime(duration);
        }
    }

    void Update()
    {
        if (_timer.Finished)
        {
            _timer.Stop();
            _speedupFactor = 1;
        }
    }
}
