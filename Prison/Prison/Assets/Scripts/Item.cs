using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum item { bottle,iron,mask,screw,wood}
    public item _item;

    public ItemProperty property;

    private GameObject[] slots;
    private bool isPlayerOn;

    void Start()
    {
        slots = SlotsRef.instance.regular;
    }

    private void Update()
    {
        if (isPlayerOn && Input.GetKeyDown(KeyCode.E))
        {
            foreach (GameObject slot in slots)
            {
                Slot _slot = slot.GetComponent<Slot>();
                if (!_slot.isFull)
                {
                    BlackBoard.playerInventory.itemsId[(int) _item]++;
                    _slot.isFull = true;
                    _slot.itemID = property.ID;
                    _slot.m_Image.sprite = property.sprite;
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
