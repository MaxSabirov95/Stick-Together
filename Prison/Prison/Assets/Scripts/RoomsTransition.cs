using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsTransition : MonoBehaviour
{
    public enum KindOfDoor { InRoom, InLobby}
    public KindOfDoor kindOfDoor;
    [SerializeField] private SpriteRenderer _enterText;
    [SerializeField] private SpriteRenderer _exitText;

    public GameObject enterRoom;
    bool isPlayerIn;

    private void Start()
    {
        enterRoom.SetActive(false);
        _enterText.enabled = false;
        _exitText.enabled = false;
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
                    _exitText.enabled = true;
                    break;
                case KindOfDoor.InLobby:
                    _enterText.enabled = true;
                    break;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            isPlayerIn = false;
            _enterText.enabled = isPlayerIn;
            _exitText.enabled = isPlayerIn;
        }
    }
}
