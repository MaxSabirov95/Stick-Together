using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public enum KinfOfProtection { Weapon,Trap}
    public KinfOfProtection kinfOfProtection;

    public ItemProperty property;
    public int weaponHP;

    private bool isPlayerOn;
    private GameObject[] trapSlots;
    private GameObject weaponSlot;

    void Start()
    {
        trapSlots = SlotsRef.instance.traps;
        weaponSlot = SlotsRef.instance.weapon;
    }

    void Update()
    {
        if (isPlayerOn && Input.GetKeyDown(KeyCode.E))
        {
            switch (kinfOfProtection)
            {
                case KinfOfProtection.Weapon:
                    WeaponSlot _weapon = weaponSlot.GetComponent<WeaponSlot>();
                    if (!_weapon.isFull)
                    {
                        _weapon.isFull = true;
                        _weapon.itemID = property.ID;
                        _weapon.m_Image.sprite = BlackBoard.allgameItems.weaponToSprite[(weapon)property.ID];
                        if (weaponHP > 1)
                        {
                            _weapon.hpText.text = weaponHP.ToString();
                            _weapon.hpText.gameObject.SetActive(true);
                        }
                        Destroy(gameObject);
                    }
                    break;
                case KinfOfProtection.Trap:
                    foreach (GameObject trapSlot in trapSlots)
                    {
                        Slot _trap = trapSlot.GetComponent<Slot>();
                        if (!_trap.isFull)
                        {
                            _trap.isFull = true;
                            _trap.itemID = property.ID;
                            _trap.m_Image.sprite = BlackBoard.allgameItems.weaponToSprite[(weapon)property.ID];
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
