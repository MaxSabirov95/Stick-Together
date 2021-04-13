using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomsTransition : MonoBehaviour
{
    public enum KindOfDoor { InRoom, InLobby}
    public KindOfDoor kindOfDoor;
    public Text doorUI;

    public GameObject enterRoom;
    bool isPlayerIn;

    private void Awake()
    {
        enterRoom.SetActive(false);
        doorUI = GameObject.FindGameObjectWithTag("Text - Enter Rooms").GetComponent<Text>();
    }

    private void Start()
    {
        doorUI.enabled = isPlayerIn;
    }

    void Update()
    {
        if (isPlayerIn)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                enterRoom.SetActive(true);
                transform.parent.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            isPlayerIn = true;
            switch (kindOfDoor)
            {
                case KindOfDoor.InRoom:
                    doorUI.text = "Press 'E' To Exit";
                    break;
                case KindOfDoor.InLobby:
                    doorUI.text = "Press 'E' To Enter";
                    break;
            }
            doorUI.enabled = isPlayerIn;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            isPlayerIn = false;
            doorUI.enabled = isPlayerIn;
        }
    }
}
