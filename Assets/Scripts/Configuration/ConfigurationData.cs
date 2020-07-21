using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// A container for the configuration data
/// </summary>
public class ConfigurationData
{
    #region Fields

    // configuration data
    const string ConfigurationDataFileName = "ConfigurationData.csv";

    #endregion

    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public static float PaddleMoveUnitsPerSecond { get; private set; } = 10;

    /// <summary>
    /// Gets the impulse force to apply to move the ball
    /// </summary>
    /// <value>impulse force</value>
    public static float BallImpulseForce { get; private set; } = 200;

    /// <summary>
    /// Gets the ball lifetime
    /// </summary>
    public static float BallLifetime { get; private set; } = 10;

    /// <summary>
    /// Gets minimum time for random spawn balls
    /// </summary>
    public static float MinSpawnTime { get; private set; } = 5;

    /// <summary>
    /// Gets maximum time for random spawn balls
    /// </summary>
    public static float MaxSpawnTime { get; private set; } = 10;

    
    /// <summary>
    /// Gets how many points standard block is worth
    /// </summary>
    public static int CostStandardBlock { get; private set; } = 1;
    
    /// <summary>
    /// Gets how many points bonus block is worth
    /// </summary>
    public static int CostBonusBlock { get; private set; } = 2;
    
    /// <summary>
    /// Gets how many points others blocks is worth
    /// </summary>
    public static int CostPickupBlocks { get; private set; } = 5;

    /// <summary>
    /// Gets how many balls maybe per games;
    /// </summary>
    public static int NumberBalls { get; private set; } = 5;

    /// <summary>
    /// Gets the probability that a standard block will be added to the level
    /// </summary>
    public static float StandardBlockProbability { get; private set; } = 0.7f;

    /// <summary>
    /// Gets the probability that a bonus block will be added to the level
    /// </summary>
    public static float BonusBlockProbability { get; private set; } = 0.2f;

    /// <summary>
    /// Gets the probability that a freezer block will be added to the level
    /// </summary>
    public static float FreezerBlockProbability { get; private set; } = 0.05f;
    
    
    /// <summary>
    /// Gets the probability that a speedup block will be added to the level
    /// </summary>
    public static float SpeedupBlockProbability { get; private set; } = 0.05f;

    /// <summary>
    /// Gets the freezer effect duration
    /// </summary>
    public static float FreezerEffectDuration { get; private set; } = 2f;

    /// <summary>
    /// Gets the speedup effect duration
    /// </summary>
    public static float SpeedupEffectDuration { get; private set; } = 4f;

    /// <summary>
    /// Gets the speedup factor increase
    /// </summary>
    public static float SpeedupFactor { get; private set; } = 2f;

    #endregion

    #region Constructor

    /// <summary>
    /// Constructor
    /// Reads configuration data from a file. If the file
    /// read fails, the object contains default values for
    /// the configuration data
    /// </summary>
    public ConfigurationData()
    {
        // Read and save configuration data from file
        StreamReader input = null;
        try
        {
            // create stream reader object
            input = File.OpenText(Path.Combine(Application.streamingAssetsPath, ConfigurationDataFileName));

            // read in names and values
            string names = input.ReadLine();
            string values = input.ReadLine();

            // set configuration data fields
            SetConfigurationDataFields(values);
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
        finally
        {
            // always close input file
            input?.Close();
        }

    }

    /// <summary>
    /// Sets the configuration data fields from the provided csv string
    /// </summary>
    /// <param name="csvValues">csv string of values</param>
    private void SetConfigurationDataFields(string csvValues)
    {
        // the code below assumes that is known the order of the provided data
        string[] values = csvValues.Split(',');
        PaddleMoveUnitsPerSecond = float.Parse(values[0]);
        BallImpulseForce = float.Parse(values[1]);
        BallLifetime = float.Parse(values[2]);
        MinSpawnTime = float.Parse(values[3]);
        MaxSpawnTime = float.Parse(values[4]);
        CostStandardBlock = int.Parse(values[5]);
        CostBonusBlock = int.Parse(values[6]);
        CostPickupBlocks = int.Parse(values[7]);
        NumberBalls = int.Parse(values[8]);
        StandardBlockProbability = float.Parse(values[9]) / 100;
        BonusBlockProbability = float.Parse(values[10]) / 100;
        FreezerBlockProbability = float.Parse(values[11]) / 100;
        SpeedupBlockProbability = float.Parse(values[12]) / 100;
        FreezerEffectDuration = float.Parse(values[13]);
        SpeedupEffectDuration = float.Parse(values[14]);
        SpeedupFactor = float.Parse(values[15]);
    }

    #endregion
}
