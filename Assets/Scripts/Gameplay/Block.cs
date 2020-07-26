using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// A block
/// </summary>
public class Block : MonoBehaviour
{
    protected int CostBlock;
    private AddPoints _addPoints;
    private BlockEvent _blockEvent;

    protected virtual void Start()
    {
        _addPoints = new AddPoints();
        EventManager.AddPointsInvoker(this);
        
        _blockEvent = new BlockEvent();
        EventManager.BlockInvoker(this);
    }
    
    /// <summary>
    /// Destroys the block on collision with ball
    /// </summary>
    /// <param name="other">collider</param>
    protected virtual void OnCollisionEnter2D(Collision2D other)
    {
        _addPoints.Invoke(CostBlock);
        _blockEvent.Invoke();
        AudioManager.Play(AudioClipName.HitBlock);
        Destroy(gameObject);
    }

    public void AddPointsAddedListener(UnityAction<int> listener)
    {
        _addPoints.AddListener(listener);
    }
    
    public void BlockListener(UnityAction listener)
    {
        _blockEvent.AddListener(listener);
    }
    
}
