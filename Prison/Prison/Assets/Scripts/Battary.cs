using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battary : MonoBehaviour
{
    public int power;
    private bool isPlayerOn;

    public Text pickUpText;

    private void Awake()
    {
        pickUpText = GameObject.FindGameObjectWithTag("Text - Pick Up").GetComponent<Text>();
    }

    private void Start()
    {
        pickUpText.enabled = isPlayerOn;
    }

    private void Update()
    {
        if (isPlayerOn && Input.GetKeyDown(KeyCode.E))
        {
            BlackBoard.flashLight.AddPower(power);
            Destroy(gameObject);
        }     
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            isPlayerOn = true;
            pickUpText.enabled = isPlayerOn;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            isPlayerOn = false;
            pickUpText.enabled = isPlayerOn;
        }
    }
}
