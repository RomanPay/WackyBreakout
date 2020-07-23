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
}
