using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashLight : MonoBehaviour
{
    public GameObject flashLight;
    bool isLightOn;
    public float maxLifeFlashLight;
    public float currentLifeFlashLight;
    public Bar flashLightBar;
    public Text flashLightPercents;

    private void Awake()
    {
        BlackBoard.flashLight = this;
    }

    void Start()
    {
        currentLifeFlashLight = maxLifeFlashLight;
        flashLightBar.SetMaxSlider(maxLifeFlashLight);
        flashLightPercents.text = maxLifeFlashLight.ToString("f0");
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
            flashLightPercents.text = currentLifeFlashLight.ToString("f0");
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
        flashLightPercents.text = currentLifeFlashLight.ToString("f0");
    }
}
