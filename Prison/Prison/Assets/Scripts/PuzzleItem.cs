using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleItem : MonoBehaviour
{
    public enum ItemType { GeneratorKey, GasCan}
    public ItemType itemType;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            switch (itemType)
            {
                case ItemType.GeneratorKey:
                    BlackBoard.gameManager.ifHaveGeneratorKey = true;
                    break;
                case ItemType.GasCan:
                    BlackBoard.gameManager.ifHaveGasCan = true;
                    break;
            }
            Destroy(gameObject);
        }
    }
}
