using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
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
    /// Gets how many points pickup blocks is worth
    /// </summary>
    public static int CostPickupBlocks => ConfigurationData.CostPickupBlocks;
    
    /// <summary>
    /// Gets how many balls maybe per games;
    /// </summary>
    public static int NumberBalls => ConfigurationData.NumberBalls;
    
    /// <summary>
    /// Gets the probability that a standard block will be added to the level 
    /// </summary>
    public static float StandardBlockProbability => ConfigurationData.StandardBlockProbability;
    
    
    /// <summary>
    /// Gets the probability that a bonus block will be added to the level
    /// </summary>
    public static float BonusBlockProbability => ConfigurationData.BonusBlockProbability;
    
    /// <summary>
    /// Gets the probability that a freezer block will be added to the level
    /// </summary>
    public static float FreezerBlockProbability => ConfigurationData.FreezerBlockProbability;
    
    /// <summary>
    /// Gets the probability that a speedup block will be added to the level
    /// </summary>
    public static float SpeedupBlockProbability => ConfigurationData.SpeedupBlockProbability;

    /// <summary>
    /// Gets the freezer effect duration
    /// </summary>
    public static float FreezerEffectDuration => ConfigurationData.FreezerEffectDuration;

    /// <summary>
    /// Gets the speedup effect duration
    /// </summary>
    public static float SpeedupEffectDuration => ConfigurationData.SpeedupEffectDuration;

    /// <summary>
    /// Gets the speedup factor increase
    /// </summary>
    public static float SpeedupFactor => ConfigurationData.SpeedupFactor;

    #endregion
}
