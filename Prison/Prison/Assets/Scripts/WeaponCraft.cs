using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCraft : ItemProperty
{
    public enum weapon { baseball, trap, flashbang }
    public weapon _weapon;
    public GameObject[] slots;
    public GameObject[] weaponSlots;

    void Start()
    {
        weaponSlots = GameObject.FindGameObjectsWithTag("Weapon Slot");
        slots = GameObject.FindGameObjectsWithTag("Slot");
    }

    public void Craft()
    {
        foreach (GameObject _weaponSlot in weaponSlots)
        {
            if (!_weaponSlot.GetComponent<Slot>().isFull)
            {
                switch (_weapon)
                {
                    case weapon.baseball:
                        if (BlackBoard.playerInventory.itemsId[4] >= 2)
                        {
                            foreach (GameObject slot in slots)
                            {
                                if (slot.GetComponent<Slot>().itemID == 4)
                                {
                                    slot.GetComponent<Slot>().itemID = 0;
                                    slot.GetComponent<Slot>().isFull = false;
                                    slot.GetComponent<Slot>().m_Image.sprite = null;
                                }
                            }
                            foreach (GameObject weaponSlot in weaponSlots)
                            {
                                if (!weaponSlot.GetComponent<Slot>().isFull)
                                {
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
                        }
                        break;
                    case weapon.trap:
                        if (BlackBoard.playerInventory.itemsId[1] >= 1 && BlackBoard.playerInventory.itemsId[3] >= 1)
                        {
                            foreach (GameObject slot in slots)
                            {
                                if (slot.GetComponent<Slot>().itemID == 1 || slot.GetComponent<Slot>().itemID == 3)
                                {
                                    slot.GetComponent<Slot>().itemID = 0;
                                    slot.GetComponent<Slot>().isFull = false;
                                    slot.GetComponent<Slot>().m_Image.sprite = null;
                                }
                            }
                            foreach (GameObject weaponSlot in weaponSlots)
                            {
                                if (!weaponSlot.GetComponent<Slot>().isFull)
                                {
                                    BlackBoard.playerInventory.itemsId[1]--;
                                    BlackBoard.playerInventory.itemsId[3]--;
                                    BlackBoard.playerInventory.itemsId[6]++;
                                    weaponSlot.GetComponent<Slot>().isFull = true;
                                    weaponSlot.GetComponent<Slot>().itemID = ID;
                                    weaponSlot.GetComponent<Slot>().m_Image.sprite = spriteR;
                                    break;
                                }
                            }
                        }
                        break;
                    case weapon.flashbang:
                        if (BlackBoard.playerInventory.itemsId[0] >= 1 && BlackBoard.playerInventory.itemsId[2] >= 1)
                        {
                            foreach (GameObject slot in slots)
                            {
                                if (slot.GetComponent<Slot>().itemID == 0 || slot.GetComponent<Slot>().itemID == 2)
                                {
                                    slot.GetComponent<Slot>().itemID = 0;
                                    slot.GetComponent<Slot>().isFull = false;
                                    slot.GetComponent<Slot>().m_Image.sprite = null;
                                }
                            }
                            foreach (GameObject weaponSlot in weaponSlots)
                            {
                                if (!weaponSlot.GetComponent<Slot>().isFull)
                                {
                                    BlackBoard.playerInventory.itemsId[0]--;
                                    BlackBoard.playerInventory.itemsId[2]--;
                                    BlackBoard.playerInventory.itemsId[7]++;
                                    weaponSlot.GetComponent<Slot>().isFull = true;
                                    weaponSlot.GetComponent<Slot>().itemID = ID;
                                    weaponSlot.GetComponent<Slot>().m_Image.sprite = spriteR;
                                    break;
                                }
                            }
                        }
                        break;
                }
            }
        }
    }
}
