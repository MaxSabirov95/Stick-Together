using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class GameManager : MonoBehaviour
{
    public bool isElectricityLeverOn;
    public GameObject lights;

    private void Awake()
    {
        BlackBoard.gameManager = this;
    }

    void Start()
    {
        isElectricityLeverOn = false;
    }

    void Update()
    {
        if (isElectricityLeverOn)
        {
            lights.GetComponent<Light2D>().intensity = 0.5f;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            BlackBoard.inGameUI.PauseMenu();
        }
    }
}
