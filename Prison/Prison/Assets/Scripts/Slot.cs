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

    public void DropItem(bool isWeapon)
    {
        if (isFull)
        {
            if (isWeapon)
            {
                BlackBoard.allgameItems.InstansiateWeapon(itemID,0);
                BlackBoard.playerInventory.itemsId[5+itemID]--;
            }
            else
            {
                BlackBoard.allgameItems.InstansiateItem(itemID);
                BlackBoard.playerInventory.itemsId[itemID]--;
            }
            
            itemID = 0;
            isFull = false;
            m_Image.sprite = null;
        }
    }

    public void EmptySlot()
    {
        itemID = 0;
        isFull = false;
        m_Image.sprite = null;
    }

    public void FillSlot(int ID ,bool isWeapon)
    {
        isFull = true;
        itemID = ID;
        if (isWeapon)
        {
            m_Image.sprite = BlackBoard.allgameItems.weaponToSprite[(weapon)ID];
        }
        else
        {
            m_Image.sprite = BlackBoard.allgameItems.itemToSprite[(item)ID];
        }
    }
}
