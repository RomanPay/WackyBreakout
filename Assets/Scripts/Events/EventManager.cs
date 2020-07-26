using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public static class EventManager
{
    // freeze event support
    private static List<PickupBlocks> _freezeEffectInvokers = new List<PickupBlocks>();
    private static List<UnityAction<int>> _freezeEffectListeners = new List<UnityAction<int>>();

    // speedup event support
    private static List<PickupBlocks> _speedupEffectInvokers = new List<PickupBlocks>();
    private static List<UnityAction<int, int>> _speedupEffectListeners = new List<UnityAction<int, int>>();
    
    // event for add point
    private static List<Block> _addPointsInvokers = new List<Block>();
    private static List<UnityAction<int>> _addPointsListeners = new List<UnityAction<int>>();

    // reduce ball left event
    private static List<Ball> _ballsLeftInvoker = new List<Ball>();
    private static List<UnityAction> _ballsLeftListener = new List<UnityAction>();
    
    // spawn ball event
    private static Ball _ballSpawnInvoker;
    private static UnityAction _ballSpawnListener;
    
    // event for last ball
    private static HUD _lastBallInvoker;
    private static UnityAction<int> _lastBallListener;

    //event for last block
    private static WackyBreakout _lastBlockInvoker;
    private static UnityAction _lastBlockListener;
    
    private static Block _blockInvoker;
    private static UnityAction _blockListener;
    
    public static void BlockInvoker(Block invoker)
    {
        _blockInvoker = invoker;
        if (_blockListener != null)
            _blockInvoker.BlockListener(_blockListener);
            
    }

    public static void BlockListener(UnityAction listener)
    {
        _blockListener = listener;
        if (_blockInvoker != null)
            _blockInvoker.BlockListener(listener);
    }
    
    public static void LastBlockInvoker(WackyBreakout invoker)
    {
        _lastBlockInvoker = invoker;
        if (_lastBlockListener != null)
            _lastBlockInvoker.LastBlockListener(_lastBlockListener);
            
    }

    public static void LastBlockListener(UnityAction listener)
    {
        _lastBlockListener = listener;
        if (_lastBlockInvoker != null)
            _lastBlockInvoker.LastBlockListener(listener);
    }
    
    public static void LastBallInvoker(HUD invoker)
    {
        _lastBallInvoker = invoker;
        if (_lastBallListener != null)
            _lastBallInvoker.LastBallAddListener(_lastBallListener);
            
    }

    public static void LastBallListener(UnityAction<int> listener)
    {
        _lastBallListener = listener;
        if (_lastBallInvoker != null)
            _lastBallInvoker.LastBallAddListener(listener);
    }
    
    public static void BallSpawnInvoker(Ball invoker)
    {
        _ballSpawnInvoker = invoker;
        if (_ballSpawnListener != null)
            _ballSpawnInvoker.SpawnBallAddListener(_ballSpawnListener);
    }

    public static void BallSpawnListener(UnityAction listener)
    {
        _ballSpawnListener = listener;
        if (_ballSpawnInvoker != null)
            _ballSpawnInvoker.SpawnBallAddListener(listener);
    }
    
    public static void BallsLeftInvokers(Ball invoker)
    {
        _ballsLeftInvoker.Add(invoker);
        foreach (UnityAction listener in _ballsLeftListener)
        {
            invoker.BallsLeftAddedListener(listener);
        }
    }

    public static void BallsLeftListeners(UnityAction listener)
    {
        _ballsLeftListener.Add(listener);
        foreach (Ball ball in _ballsLeftInvoker)
        {
            ball.BallsLeftAddedListener(listener);
        }
    }
    
    /// <summary>
    /// Add invoker for score point event
    /// </summary>
    /// <param name="invoker">invoker</param>
    public static void AddPointsInvoker(Block invoker)
    {
        _addPointsInvokers.Add(invoker);
        foreach (UnityAction<int> listener in _addPointsListeners)
            invoker.AddPointsAddedListener(listener);
    }

    /// <summary>
    /// Add listener for score point event
    /// </summary>
    /// <param name="listener">listener</param>
    public static void AddPointsListener(UnityAction<int> listener)
    {
        _addPointsListeners.Add(listener);
        foreach (Block block in _addPointsInvokers)
        {
            block.AddPointsAddedListener(listener);
        }
    }
    
    /// <summary>
    /// Adds invoker for the freeze event
    /// </summary>
    /// <param name="invoker">invoker</param>
    public static void AddFreezeEffectInvoker(PickupBlocks invoker)
    {
        _freezeEffectInvokers.Add(invoker);
        foreach (UnityAction<int> listener in _freezeEffectListeners)
        {
            invoker.AddFreezerEffectListener(listener);
        }
    }

    /// <summary>
    /// Adds listener for the freeze event
    /// </summary>
    /// <param name="listener">listener</param>
    public static void AddFreezeEffectListener(UnityAction<int> listener)
    {
        _freezeEffectListeners.Add(listener);
        foreach (PickupBlocks invoker in _freezeEffectInvokers)
        {
            invoker.AddFreezerEffectListener(listener);
        }
    }

    /// <summary>
    /// Adds invoker for the speedup event
    /// </summary>
    /// <param name="invoker">invoker</param>
    public static void AddSpeedupEffectInvoker(PickupBlocks invoker)
    {
        _speedupEffectInvokers.Add(invoker);
        foreach (UnityAction<int, int> listener in _speedupEffectListeners)
            invoker.AddSpeedupEffectListener(listener);
        
    }

    /// <summary>
    /// Adds listener for the speedup event
    /// </summary>
    /// <param name="listener">listener</param>
    public static void AddSpeedupEffectListener(UnityAction<int, int> listener)
    {
        _speedupEffectListeners.Add(listener);
        foreach (PickupBlocks pickupBlocks in _speedupEffectInvokers)
            pickupBlocks.AddSpeedupEffectListener(listener);
    }
}
