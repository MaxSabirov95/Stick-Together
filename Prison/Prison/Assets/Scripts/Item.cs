using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ItemProperty
{
    public enum item { bottle,iron,mask,screw,wood}
    public item _item;
    public GameObject[] slots;

    bool isPlayerOn;

    void Start()
    {
        slots = GameObject.FindGameObjectsWithTag("Slot");
    }

    private void Update()
    {
        if (isPlayerOn && Input.GetKeyDown(KeyCode.E))
        {
            foreach (GameObject slot in slots)
            {
                if (!slot.GetComponent<Slot>().isFull)
                {
                    switch (_item)
                    {
                        case item.bottle:
                            BlackBoard.playerInventory.itemsId[0]++;
                            break;
                        case item.iron:
                            BlackBoard.playerInventory.itemsId[1]++;
                            break;
                        case item.mask:
                            BlackBoard.playerInventory.itemsId[2]++;
                            break;
                        case item.screw:
                            BlackBoard.playerInventory.itemsId[3]++;
                            break;
                        case item.wood:
                            BlackBoard.playerInventory.itemsId[4]++;
                            break;
                    }
                    slot.GetComponent<Slot>().isFull = true;
                    slot.GetComponent<Slot>().itemID = ID;
                    slot.GetComponent<Slot>().m_Image.sprite = spriteR;
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            isPlayerOn = true;  
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            isPlayerOn = false;
        }
    }
}
