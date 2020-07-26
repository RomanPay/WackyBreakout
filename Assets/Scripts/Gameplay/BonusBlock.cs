using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BonusBlock : Block
{
    protected override void Start()
    {
        base.Start();
        CostBlock = ConfigurationUtils.CostBonusBlock;
    }

    protected override void OnCollisionEnter2D(Collision2D other)
    {
        base.OnCollisionEnter2D(other);
        AudioManager.Play(AudioClipName.BonusBlock);
    }
}
