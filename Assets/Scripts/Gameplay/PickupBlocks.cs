using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PickupBlocks : Block
{
    [SerializeField] private Sprite spriteFreezerBlock;
    [SerializeField] private Sprite spriteFasterBlock;

    private PickupEffect _effect;
    
    void Start()
    {
        CostBlock = ConfigurationUtils.CostPickupBlocks;
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
            
            // set sprite
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = _effect == PickupEffect.Freezer ? spriteFreezerBlock : spriteFasterBlock;
        }
    }
}
