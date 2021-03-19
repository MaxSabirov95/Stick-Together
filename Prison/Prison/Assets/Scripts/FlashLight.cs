using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public GameObject flashLight;
    bool isLightOn;

    void Start()
    {
        isLightOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            TurnOnOff();
        }
    }

    void TurnOnOff()
    {
        isLightOn = !isLightOn;
        flashLight.SetActive(isLightOn);
    }
}
