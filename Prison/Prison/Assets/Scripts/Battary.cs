using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battary : MonoBehaviour
{
    public int power;
    private bool isPlayerOn;

    private void Update()
    {
        if (isPlayerOn && Input.GetKeyDown(KeyCode.E))
        {
            BlackBoard.flashLight.AddPower(power);
            Destroy(gameObject);
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
