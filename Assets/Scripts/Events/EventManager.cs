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
