using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public bool isFull;
    public Button button;
    public int itemID;

    public Image m_Image;

    void Start()
    {
        isFull = false;

        m_Image = GetComponent<Image>();
    }

    public void DropItem()
    {
        if (isFull)
        {
            BlackBoard.allgameItems.InstansiateItem(itemID);
            BlackBoard.playerInventory.itemsId[itemID]--;
            itemID = 0;
            isFull = false;
            m_Image.sprite = null;
        }
    }
}
