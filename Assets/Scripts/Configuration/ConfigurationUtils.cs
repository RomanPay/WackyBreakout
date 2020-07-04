using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public static class ConfigurationUtils
{
    #region Properties
    
    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public static float PaddleMoveUnitsPerSecond => ConfigurationData.PaddleMoveUnitsPerSecond;

    /// <summary>
    /// Gets the impulse force to apply to the move the balls
    /// </summary>
    public static float BallImpulseForce => ConfigurationData.BallImpulseForce;

    /// <summary>
    /// Gets the lifetime balls
    /// </summary>
    public static float BallLifetime => ConfigurationData.BallLifetime;

    /// <summary>
    /// Gets minimum time for random spawn balls
    /// </summary>
    public static float MinSpawnTime => ConfigurationData.MinSpawnTime;

    /// <summary>
    /// Gets maximum time for random spawn balls
    /// </summary>
    public static float MaxSpawnTime => ConfigurationData.MaxSpawnTime;

    /// <summary>
    /// Gets how many points standard block is worth
    /// </summary>
    public static int CostStandardBlock => ConfigurationData.CostStandardBlock;
    
    /// <summary>
    /// Gets how many points bonus block is worth
    /// </summary>
    public static int CostBonusBlock => ConfigurationData.CostBonusBlock;
    
    /// <summary>
    /// Gets how many points others blocks is worth
    /// </summary>
    public static int CostPickupBlocks => ConfigurationData.CostPickupBlocks;
    
    /// <summary>
    /// Gets how many balls maybe per games;
    /// </summary>
    public static int NumberBalls => ConfigurationData.NumberBalls;

    #endregion
}
