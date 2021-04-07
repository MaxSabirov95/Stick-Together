using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum weapon { baseball, trap, flashbang }
public class WeaponCraft : MonoBehaviour
{
    public weapon _weapon;
    private GameObject[] slots;
    private GameObject[] trapSlots;
    private WeaponSlot weaponSlot;
    public int ID;

    void Start()
    {
        trapSlots = SlotsRef.instance.traps;
        weaponSlot = SlotsRef.instance.weapon.GetComponent<WeaponSlot>();
        slots = SlotsRef.instance.regular;
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
                        weaponSlot.FillSlot(ID,true);
                        weaponSlot.hpText.gameObject.SetActive(true);
                        weaponSlot.hpText.text = "100";
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
                                    trapSlot.GetComponent<Slot>().FillSlot(ID,true);
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
                                    trapSlot.GetComponent<Slot>().FillSlot(ID,true);
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
                            slot.GetComponent<Slot>().EmptySlot();
                            slot1.GetComponent<Slot>().EmptySlot();
                            break;
                        }
                    }
                }
                break;
            }
        }
    }
}
