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

    protected virtual void Start()
    {
        _addPoints = new AddPoints();
        EventManager.AddPointsInvoker(this);
    }
    
    /// <summary>
    /// Destroys the block on collision with ball
    /// </summary>
    /// <param name="other">collider</param>
    protected virtual void OnCollisionEnter2D(Collision2D other)
    {
        _addPoints.Invoke(CostBlock);
        Destroy(gameObject);
    }

    public void AddPointsAddedListener(UnityAction<int> listener)
    {
        _addPoints.AddListener(listener);
    }
}
