using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class StandardBlock : Block
{
    [SerializeField] private Sprite[] spriteStandardBlock = new Sprite[10];
    private AddPoints _addPoints;

    protected override void Start()
    {
        base.Start();
        CostBlock = ConfigurationUtils.CostStandardBlock;
        GetComponent<SpriteRenderer>().sprite = spriteStandardBlock[Random.Range(0, 10)];
    }
}
