using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A block
/// </summary>
public class Block : MonoBehaviour
{
    protected int CostBlock;
    
    /// <summary>
    /// Destroys the block on collision with ball
    /// </summary>
    /// <param name="other">collider</param>
    protected virtual void OnCollisionEnter2D(Collision2D other)
    {
        HUD.AddScorePoints(CostBlock);
        Destroy(gameObject);
    }
}
