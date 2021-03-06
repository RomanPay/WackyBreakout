﻿using System;
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

    protected override void Start()
    {
        base.Start();
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
        base.OnCollisionEnter2D(other);
        if (_effect == PickupEffect.Freezer)
        {
            _freezerEffectActivated.Invoke(_freezeEffectDuration);
            AudioManager.Play(AudioClipName.FreezeEffectStart);
        }
        else if (_effect == PickupEffect.Speedup)
        {
            _speedupEffectActivated.Invoke(_speedupEffectDuration, _speedupFactor);
            AudioManager.Play(AudioClipName.SpeedupEffect);
        }
        
    }
}

