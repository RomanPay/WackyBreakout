using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EffectUtils
{
    /// <summary>
    /// Gets if running speedup effect
    /// </summary>
    public static bool SpeedupEffectActive => GetSpeedupEffectMonitor().SpeedupEffectActive;

    /// <summary>
    /// Gets time to finish current timer keep of track speedup effect
    /// </summary>
    public static float TimerLeft => GetSpeedupEffectMonitor().TimeToFinish;

    /// <summary>
    /// Gets speedup factor to increase speed balls 
    /// </summary>
    public static int SpeedupFactor => GetSpeedupEffectMonitor().SpeedupFactor;

    private static SpeedupEffectMonitor GetSpeedupEffectMonitor()
    {
        return Camera.main.GetComponent<SpeedupEffectMonitor>();
    }
}
