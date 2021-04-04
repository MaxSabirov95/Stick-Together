using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCraft : ItemProperty
{
    public enum weapon { baseball, trap, flashbang }
    public weapon _weapon;
    public GameObject[] slots;
    public GameObject[] trapSlots;
    public GameObject weaponSlot;

    void Start()
    {
        trapSlots = GameObject.FindGameObjectsWithTag("Trap Slot");
        weaponSlot = GameObject.FindGameObjectWithTag("Weapon Slot");
        slots = GameObject.FindGameObjectsWithTag("Slot");
    }

    public void Craft()
    {
        switch (_weapon)
        {
            case weapon.baseball:
                if (BlackBoard.playerInventory.itemsId[4] >= 2)
                {
                    if (!weaponSlot.GetComponent<Slot>().isFull)
                    {
                        MergeItems(4,4);
                        BlackBoard.playerInventory.itemsId[4] -= 2;
                        BlackBoard.playerInventory.itemsId[5]++;
                        weaponSlot.GetComponent<Slot>().isFull = true;
                        weaponSlot.GetComponent<Slot>().itemID = ID;
                        weaponSlot.GetComponent<Slot>().m_Image.sprite = spriteR;
                        weaponSlot.GetComponent<Slot>().hpText.gameObject.SetActive(true);
                        weaponSlot.GetComponent<Slot>().hpText.text = 100.ToString();
                        break;
                    }
                }
                break;
        }
        foreach (GameObject _weaponSlot in trapSlots)
        {
            if (!_weaponSlot.GetComponent<Slot>().isFull)
            {
                switch (_weapon)
                {
                    case weapon.trap:
                        if (BlackBoard.playerInventory.itemsId[1] >= 1 && BlackBoard.playerInventory.itemsId[3] >= 1)
                        {
                            MergeItems(1, 3);
                            foreach (GameObject trapSlot in trapSlots)
                            {
                                if (!trapSlot.GetComponent<Slot>().isFull)
                                {
                                    BlackBoard.playerInventory.itemsId[1]--;
                                    BlackBoard.playerInventory.itemsId[3]--;
                                    BlackBoard.playerInventory.itemsId[6]++;
                                    trapSlot.GetComponent<Slot>().isFull = true;
                                    trapSlot.GetComponent<Slot>().itemID = ID;
                                    trapSlot.GetComponent<Slot>().m_Image.sprite = spriteR;
                                    break;
                                }
                            }
                        }
                        break;
                    case weapon.flashbang:
                        if (BlackBoard.playerInventory.itemsId[0] >= 1 && BlackBoard.playerInventory.itemsId[2] >= 1)
                        {
                            MergeItems(0, 2);
                            foreach (GameObject trapSlot in trapSlots)
                            {
                                if (!trapSlot.GetComponent<Slot>().isFull)
                                {
                                    BlackBoard.playerInventory.itemsId[0]--;
                                    BlackBoard.playerInventory.itemsId[2]--;
                                    BlackBoard.playerInventory.itemsId[7]++;
                                    trapSlot.GetComponent<Slot>().isFull = true;
                                    trapSlot.GetComponent<Slot>().itemID = ID;
                                    trapSlot.GetComponent<Slot>().m_Image.sprite = spriteR;
                                    break;
                                }
                            }
                        }
                        break;
                }
            }
        }
    }

    public void MergeItems(int item1, int item2)
    {
        foreach (GameObject slot in slots)
        {
            if (slot.GetComponent<Slot>().itemID == item1)
            {
                foreach (GameObject slot1 in slots)
                {
                    if (slot != slot1)
                    {
                        if (slot1.GetComponent<Slot>().itemID == item2)
                        {
                            slot.GetComponent<Slot>().itemID = 0;
                            slot.GetComponent<Slot>().isFull = false;
                            slot.GetComponent<Slot>().m_Image.sprite = null;
                            slot1.GetComponent<Slot>().itemID = 0;
                            slot1.GetComponent<Slot>().isFull = false;
                            slot1.GetComponent<Slot>().m_Image.sprite = null;
                            break;
                        }
                    }
                }
                break;
            }
        }
    }
}
