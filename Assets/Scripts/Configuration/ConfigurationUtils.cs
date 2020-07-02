using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public static class ConfigurationUtils
{
    #region Fields

    static ConfigurationData ConfigurationData;

    #endregion

    #region Properties
    
    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public static float PaddleMoveUnitsPerSecond => ConfigurationData.PaddleMoveUnitsPerSecond;

    public static float BallImpulseForce => ConfigurationData.BallImpulseForce;

    #endregion
    
    /// <summary>
    /// Initializes the configuration utils
    /// </summary>
    public static void Initialize()
    {
        ConfigurationData = new ConfigurationData();
    }
}
