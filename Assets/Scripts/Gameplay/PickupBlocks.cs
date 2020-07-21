using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class PickupBlocks : Block
{
    [SerializeField] private Sprite spriteFreezerBlock;
    [SerializeField] private Sprite spriteFasterBlock;

    private PickupEffect _effect;
    private FreezerEffectActivated _freezerEffectActivated;
    private SpeedupEffectActivated _speedupEffectActivated;
    private int _freezeEffectDuration;
    private int _speedupEffectDuration;
    private int _speedupFactor;

    void Start()
    {
        CostBlock = ConfigurationUtils.CostPickupBlocks;
       
        EventManager.AddFreezeEffectInvoker(this);
        EventManager.AddSpeedupEffectInvoker(this);
        
        _freezeEffectDuration = (int)ConfigurationUtils.FreezerEffectDuration;

        _speedupEffectDuration = (int)ConfigurationUtils.SpeedupEffectDuration;
        _speedupFactor = (int)ConfigurationUtils.SpeedupFactor;
    }

    /// <summary>
    /// Set the effect for the pickup
    /// </summary>
    /// <value>pickup effect</value>
    public PickupEffect Effect
    {
        set
        {
            _effect = value;
            
            _freezerEffectActivated = new FreezerEffectActivated();
            _speedupEffectActivated = new SpeedupEffectActivated();

            
            // set sprite
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            if (_effect == PickupEffect.Freezer)
            {
                spriteRenderer.sprite = spriteFreezerBlock;
            }
            else if (_effect == PickupEffect.Speedup)
            {
                spriteRenderer.sprite = spriteFasterBlock;
            }
        }
    }

    public void AddFreezerEffectListener(UnityAction<int> listener)
    {
        _freezerEffectActivated.AddListener(listener);  
    }

    public void AddSpeedupEffectListener(UnityAction<int, int> listener)
    {
        _speedupEffectActivated.AddListener(listener);
    }
    
    protected override void OnCollisionEnter2D(Collision2D other)
    {
        // Debug.Log("Now " + _effect);
        
        if (_effect == PickupEffect.Freezer)
        {
            _freezerEffectActivated.Invoke(_freezeEffectDuration);
            // Debug.Log("Settings freeze...");
        }
        else if (_effect == PickupEffect.Speedup)
        {
            _speedupEffectActivated.Invoke(_speedupEffectDuration, _speedupFactor);
            // Debug.Log("Settings speedup...");
        }
        
        base.OnCollisionEnter2D(other);
        // HUD.AddScorePoints(CostBlock);
        // Destroy(gameObject);
    }
}

