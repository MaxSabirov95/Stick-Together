using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    bool isPlayerNearLever;

    void Start()
    {
        isPlayerNearLever = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isPlayerNearLever)
        {
            BlackBoard.gameManager.isElectricityLeverOn = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            isPlayerNearLever = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            isPlayerNearLever = false;
        }
    }
}
