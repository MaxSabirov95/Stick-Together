using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public GameObject flashLight;
    bool isLightOn;
    public float maxLifeFlashLight;
    public float currentLifeFlashLight;
    public Bar flashLightBar;

    private void Awake()
    {
        BlackBoard.flashLight = this;
    }

    void Start()
    {
        currentLifeFlashLight = maxLifeFlashLight;
        flashLightBar.SetMaxSlider(maxLifeFlashLight);
        isLightOn = true;
    }

    public void TurnOnOff()
    {
        isLightOn = !isLightOn;
        flashLight.SetActive(isLightOn);
    }

    public void CheckLight()
    {
        if (currentLifeFlashLight > 0 && isLightOn)
        {
            currentLifeFlashLight -= Time.deltaTime * 0.25f;
            flashLightBar.SetSlider(currentLifeFlashLight); 
        }
        else
        {
            isLightOn = false;
            flashLight.SetActive(isLightOn);
        }
    }

    public void AddPower(int power)
    {
        currentLifeFlashLight += power;
        if (currentLifeFlashLight > maxLifeFlashLight)
        {
            currentLifeFlashLight = maxLifeFlashLight;
        }
        flashLightBar.SetSlider(currentLifeFlashLight);
    }
}
