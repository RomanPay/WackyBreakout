using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BonusBlock : Block
{
    void Start()
    {
        CostBlock = ConfigurationUtils.CostBonusBlock;
    }
}
