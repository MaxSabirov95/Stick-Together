using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class GameManager : MonoBehaviour
{
    public bool isElectricityLeverOn;
    public GameObject lights;
    public bool ifHaveGeneratorKey;
    public bool ifHaveGasCan;
    public Transform inWhichRoomPlayer;//For items drop

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
        BlackBoard.flashLight.CheckLight();

        if (isElectricityLeverOn)
        {
            lights.GetComponent<Light2D>().intensity = 0.5f;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            BlackBoard.flashLight.TurnOnOff();
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            BlackBoard.inGameUI.PauseMenu();
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            BlackBoard.inGameUI.Map();
        }
    }
}
