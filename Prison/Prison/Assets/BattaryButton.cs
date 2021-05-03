using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BattaryButton : MonoBehaviour, IUpdateSelectedHandler, IPointerDownHandler, IPointerUpHandler
{
    public int percent;
    bool isPressed;
    public Text percents;
    float time =0.5f;

    private void Start()
    {
        BlackBoard.battaryButton = this;
    }

    public void AddPercents(int add)
    {
        percent += add;
        percents.text = percent.ToString();
    }

    public void OnUpdateSelected(BaseEventData data)
    {
        Debug.Log(percent);
        if (isPressed)
        {
            time -= Time.deltaTime;
            if (percent > 0 && time<0)
            {
                BlackBoard.flashLight.AddPower(1);
                percent--;
                percents.text = percent.ToString();
                time = 0.5f;
            }
        }
    }
    public void OnPointerDown(PointerEventData data)
    {
        isPressed = true;
    }
    public void OnPointerUp(PointerEventData data)
    {
        isPressed = false;
    }
}
