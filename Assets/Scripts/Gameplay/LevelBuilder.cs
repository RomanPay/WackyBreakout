using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelBuilder : MonoBehaviour
{
    [SerializeField] private GameObject prefabPaddle;
    [SerializeField] private GameObject prefabBall;
    [SerializeField] private GameObject prefabStandardBlock;
    [SerializeField] private GameObject prefabBonusBlock;
    [SerializeField] private GameObject prefabPickupBlock;

    private void Start()
    {
        Instantiate(prefabPaddle);
        FillScreenBlock();
    }

    private void FillScreenBlock()
    {
        // Get block size
        GameObject tempBlock = Instantiate(prefabStandardBlock);
        float blockHeight = tempBlock.GetComponent<BoxCollider2D>().size.y;
        float blockWidth = tempBlock.GetComponent<BoxCollider2D>().size.x;
        Destroy(tempBlock);

        // Set start position for filing screen blocks
        Vector2 startPosition = new Vector2(ScreenUtils.ScreenLeft + blockWidth / 2,
                                            ScreenUtils.ScreenTop - blockHeight * 6);

        // Blocks per row with. Add +1 due to rounding down float at cast to int
        int blockPerRow = (int)((ScreenUtils.ScreenRight - ScreenUtils.ScreenLeft) / blockWidth) + 1; 
        
        // add rows of blocks
        Vector2 currentPosition = new Vector2(startPosition.x, startPosition.y);
        for (int row = 0; row < 3; row++)
        {
            for (int column = 0; column < blockPerRow; column++)
            {
                PlaceBlock(currentPosition);
                currentPosition.x += blockWidth;
            }

            // move to next row
            currentPosition.x = startPosition.x;
            currentPosition.y += blockHeight;
        }
    }

    /// <summary>
    /// Places a random selected block at the given position
    /// </summary>
    /// <param name="position">position of the block</param>
    private void PlaceBlock(Vector2 position)
    {
        float randomBlockType = Random.value;
        if (randomBlockType < ConfigurationUtils.StandardBlockProbability)
            Instantiate(prefabStandardBlock, position, Quaternion.identity);
        else if (randomBlockType <
                 ConfigurationUtils.StandardBlockProbability + ConfigurationUtils.BonusBlockProbability)
            Instantiate(prefabBonusBlock, position, Quaternion.identity);
        else
        {
            // pickup block selected
            GameObject pickupBlock = Instantiate(prefabPickupBlock, position, Quaternion.identity);
            PickupBlocks pickupBlockScript = pickupBlock.GetComponent<PickupBlocks>();

            // set pickup effect
            float freezerThreshold = ConfigurationUtils.StandardBlockProbability +
                                     ConfigurationUtils.BonusBlockProbability +
                                     ConfigurationUtils.FreezerBlockProbability;
            pickupBlockScript.Effect = randomBlockType < freezerThreshold ?
                PickupEffect.Freezer : PickupEffect.Speedup;
        }
    }
}
