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
        int choose = Random.Range(0, 2);
        switch (choose)
        {
            case 0:
                GetComponent<SpriteRenderer>().sprite = spriteFasterBlock;
                _effect = PickupEffect.Speedup;
                break;
            case 1:
                GetComponent<SpriteRenderer>().sprite = spriteFreezerBlock;
                _effect = PickupEffect.Freezer;
                break;
        }
        CostBlock = ConfigurationUtils.CostPickupBlocks;
    }
}
