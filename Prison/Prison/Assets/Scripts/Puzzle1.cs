using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1 : MonoBehaviour
{
    bool isPlayerIn;
    public GameObject prisonDoorArea; //Has a roomtransition component
    public GameObject _light;

    private void Awake()
    {
        prisonDoorArea.SetActive(false);
        _light.SetActive(false);
    }
    void Update()
    {
        if (isPlayerIn)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _light.SetActive(true);
                prisonDoorArea.SetActive(true);
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
