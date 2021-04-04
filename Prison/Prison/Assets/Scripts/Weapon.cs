using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : ItemProperty
{
    public enum KinfOfProtection { Weapon,Trap}
    public KinfOfProtection kinfOfProtection;

    public GameObject[] trapSlots;
    public GameObject weaponSlot;

    bool isPlayerOn;
    public int weaponHP;

    void Start()
    {
        trapSlots = GameObject.FindGameObjectsWithTag("Trap Slot");
        weaponSlot = GameObject.FindGameObjectWithTag("Weapon Slot");
    }

    void Update()
    {
        if (isPlayerOn && Input.GetKeyDown(KeyCode.E))
        {
            switch (kinfOfProtection)
            {
                case KinfOfProtection.Weapon:
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
                    }
                    break;
                case KinfOfProtection.Trap:
                    foreach (GameObject trapSlot in trapSlots)
                    {
                        if (!trapSlot.GetComponent<Slot>().isFull)
                        {
                            trapSlot.GetComponent<Slot>().isFull = true;
                            trapSlot.GetComponent<Slot>().itemID = ID;
                            trapSlot.GetComponent<Slot>().m_Image.sprite = spriteR;
                            Destroy(gameObject);
                            break;
                        }
                    }
                    break;
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
