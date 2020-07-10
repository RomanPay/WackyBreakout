using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public static class EventManager
{
    // freeze event support
    private static PickupBlocks _freezeEffectInvoker;
    private static UnityAction<int> _freezeEffectListener;

    // speedup event support
    private static List<PickupBlocks> _speedupEffectInvoker = new List<PickupBlocks>();
    private static List<UnityAction<int, int>> _speedupEffectListener = new List<UnityAction<int, int>>();

    /// <summary>
    /// Adds invoker for the freeze event
    /// </summary>
    /// <param name="invoker">invoker</param>
    public static void AddFreezeEffectInvoker(PickupBlocks invoker)
    {
        _freezeEffectInvoker = invoker;
        if (_freezeEffectListener != null)
            _freezeEffectInvoker.AddFreezerEffectListener(_freezeEffectListener);
    }

    /// <summary>
    /// Adds listener for the freeze event
    /// </summary>
    /// <param name="listener">listener</param>
    public static void AddFreezeEffectListener(UnityAction<int> listener)
    {
        _freezeEffectListener = listener;
        if (_freezeEffectInvoker != null)
            AddFreezeEffectInvoker(_freezeEffectInvoker);
    }

    /// <summary>
    /// Adds invoker for the speedup event
    /// </summary>
    /// <param name="invoker">invoker</param>
    public static void AddSpeedupEffectInvoker(PickupBlocks invoker)
    {
        _speedupEffectInvoker.Add(invoker);
        foreach (UnityAction<int, int> listener in _speedupEffectListener)
            invoker.AddSpeedupEffectListener(listener);
        
    }

    /// <summary>
    /// Adds listener for the speedup event
    /// </summary>
    /// <param name="listener">listener</param>
    public static void AddSpeedupEffectListener(UnityAction<int, int> listener)
    {
        _speedupEffectListener.Add(listener);
        foreach (PickupBlocks pickupBlocks in _speedupEffectInvoker)
            pickupBlocks.AddSpeedupEffectListener(listener);
    }
}
