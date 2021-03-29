using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : ItemProperty
{
    public GameObject[] weaponSlots;
    bool isPlayerOn;
    public int weaponHP;

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
                    if (weaponHP > 1)
                    {
                        weaponSlot.GetComponent<Slot>().hpText.text = weaponHP.ToString();
                        weaponSlot.GetComponent<Slot>().hpText.gameObject.SetActive(true);
                    }
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
