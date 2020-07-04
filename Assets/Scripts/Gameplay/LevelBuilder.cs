using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelBuilder : MonoBehaviour
{
    [SerializeField] private GameObject prefabPaddle;
    [SerializeField] private GameObject prefabBall;
    [SerializeField] private GameObject[] prefabsBlock = new GameObject[3];

    private void Start()
    {
        Instantiate(prefabPaddle);
        Instantiate(prefabBall);
        FillScreenBlock();
    }

    private void FillScreenBlock()
    {
        GameObject tempBlock = Instantiate(prefabsBlock[0]);

        float blockHeight = tempBlock.GetComponent<BoxCollider2D>().size.y;
        float blockWidth = tempBlock.GetComponent<BoxCollider2D>().size.x;
        
        Vector2 startPosition = new Vector2(ScreenUtils.ScreenLeft + blockWidth / 2,
                                            ScreenUtils.ScreenTop - blockHeight * 6);
        Destroy(tempBlock);

        int i = 0;
        int j = 0;
        while (i < 3)
        {
            while (j < (ScreenUtils.ScreenRight - ScreenUtils.ScreenLeft) / blockWidth)
            {
                Instantiate(prefabsBlock[Random.Range(0,3)], 
                    new Vector3(startPosition.x + blockWidth * j, startPosition.y - blockHeight * i), 
                            Quaternion.identity);
                j++;
            }
            i++;
            j = 0;
        }
    }
}
