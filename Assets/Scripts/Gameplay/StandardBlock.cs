using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class StandardBlock : Block
{
    [SerializeField] private Sprite[] spriteStandardBlock = new Sprite[10];

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = spriteStandardBlock[Random.Range(0, 10)];
        CostBlock = ConfigurationUtils.CostStandardBlock;
    }
}
