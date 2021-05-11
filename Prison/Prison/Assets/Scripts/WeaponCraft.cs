using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum weapon { baseball, trap, flashbang }
public class WeaponCraft : MonoBehaviour
{
    public weapon _weapon;
    private GameObject[] slots;
    private GameObject[] trapSlots;
    private GameObject weaponSlot;
    public int ID;
    public bool isWeapon;

    void Start()
    {
        trapSlots = SlotsRef.instance.traps;
        weaponSlot = SlotsRef.instance.weapon;
        slots = SlotsRef.instance.regular;
    }

    public void Craft()
    {
        switch (_weapon)
        {
            case weapon.baseball:
                if (!weaponSlot.GetComponent<Slot>().isFull)
                {
                    MergeItems(4, 4, 5);
                    if (!weaponSlot.GetComponent<Slot>().isFull)
                    {
                        break;
                    }
                    weaponSlot.GetComponent<WeaponSlot>().hpText.gameObject.SetActive(true);
                    weaponSlot.GetComponent<WeaponSlot>().hpText.text = "100";
                    break;
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
                        MergeItems(1, 3, 6);
                        break;
                    case weapon.flashbang:
                        MergeItems(0, 2, 7);
                        break;
                }
                break;
            }
        }
    }

    public void MergeItems(int item1, int item2 , int result)
    {
        if ((item1 == item2) && (BlackBoard.playerInventory.itemsId[item1] < 2))
        {
            return;
        }
        else if (BlackBoard.playerInventory.itemsId[item1] < 1 && BlackBoard.playerInventory.itemsId[item2] < 1)
        {
            return;
        }

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
                            slot.GetComponent<Slot>().EmptySlot();
                            slot1.GetComponent<Slot>().EmptySlot();
                            BlackBoard.playerInventory.itemsId[item1]--;
                            BlackBoard.playerInventory.itemsId[item2]--;
                            BlackBoard.playerInventory.itemsId[result]++;
                            if (isWeapon)
                            {
                                weaponSlot.GetComponent<Slot>().FillSlot(ID, true);
                            }
                            else
                            {
                                foreach (GameObject trapSlot in trapSlots)
                                {
                                    if (!trapSlot.GetComponent<Slot>().isFull)
                                    {
                                        trapSlot.GetComponent<Slot>().FillSlot(ID, true);
                                        break;
                                    }
                                }
                            }
                            break;
                        }
                    }
                }
                break;
            }
        }
    }
}
