using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsTransition : MonoBehaviour
{
    public GameObject enterRoom;
    bool isPlayerIn;

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
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            isPlayerIn = false;
        }
    }
}
