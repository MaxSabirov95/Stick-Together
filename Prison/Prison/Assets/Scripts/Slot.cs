﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public bool isFull;
    public Button button;
    public int itemID;
    public Text hpText;

    public Image m_Image;

    void Start()
    {
        isFull = false;
        if (hpText == null) hpText = null;
        m_Image = GetComponent<Image>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (int.Parse(hpText.text) > 1)
            {
                int num = int.Parse(hpText.text);
                num -= Random.Range(8, 12);
                hpText.text = num.ToString();
            }
            if(int.Parse(hpText.text)<=0)
            {
                BlackBoard.playerInventory.itemsId[itemID]--;
                itemID = 0;
                isFull = false;
                m_Image.sprite = null;
                hpText.text = 0.ToString();
                hpText.gameObject.SetActive(false);
            }
        }
    }///TEST ONLY _____ AFTER IT DELETE ALL UPDATE

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

    public void DropWeapon()
    {
        if (isFull)
        {
            try
            {
                BlackBoard.allgameItems.InstansiateWeapon(itemID, int.Parse(hpText.text));
                hpText.text = 0.ToString();
                hpText.gameObject.SetActive(false);
            }
            catch (System.NullReferenceException)
            {

                BlackBoard.allgameItems.InstansiateTrap(itemID);
            }
            BlackBoard.playerInventory.itemsId[itemID]--;
            itemID = 0;
            isFull = false;
            m_Image.sprite = null;
        }
    }

    public void WeaponHP(int weaponHP)
    {
        hpText.text = weaponHP.ToString();
    }
}
