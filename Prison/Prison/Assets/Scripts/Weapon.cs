using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : ItemProperty
{

    public GameObject[] weaponSlots;
    bool isPlayerOn;

    void Start()
    {
        weaponSlots = GameObject.FindGameObjectsWithTag("Weapon Slot");
    }

    void Update()
    {
        if (isPlayerOn && Input.GetKeyDown(KeyCode.E))
        {
            foreach (GameObject weaponSlot in weaponSlots)
            {
                if (!weaponSlot.GetComponent<Slot>().isFull)
                {
                    weaponSlot.GetComponent<Slot>().isFull = true;
                    weaponSlot.GetComponent<Slot>().itemID = ID;
                    weaponSlot.GetComponent<Slot>().m_Image.sprite = spriteR;
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
