using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public enum item { bottle, iron, mask, screw, wood }
public class Item : MonoBehaviour
{
    public item _item;

    public ItemProperty property;

    private GameObject[] slots;
    private bool isPlayerOn;
    [SerializeField] private SpriteRenderer _text;

    //public Text pickUpText;

    //private void Awake()
    //{
    //    pickUpText = GameObject.FindGameObjectWithTag("Text - Pick Up").GetComponent<Text>();
    //}

    void Start()
    {
        slots = SlotsRef.instance.regular;
        _text.enabled = false;

        //pickUpText.enabled = isPlayerOn;
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
                    _slot.m_Image.sprite = BlackBoard.allgameItems.itemToSprite[_item];
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            isPlayerOn = true;
            _text.enabled = true;
            //pickUpText.enabled = isPlayerOn;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            isPlayerOn = false;
            _text.enabled = false;
            //pickUpText.enabled = isPlayerOn;
        }
    }
}
