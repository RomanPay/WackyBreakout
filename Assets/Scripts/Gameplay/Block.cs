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

    void Start()
    {
        CostBlock = ConfigurationUtils.CostStandardBlock;
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        HUD hud = GameObject.FindWithTag("HUD").GetComponent<HUD>();
        hud.AddScorePoints(CostBlock);
        Destroy(gameObject);
    }
}
