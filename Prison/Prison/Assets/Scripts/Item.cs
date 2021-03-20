using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject[] slots;
    public Sprite spriteR;
    public int ID;

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
