using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUI : MonoBehaviour
{
    public GameObject crafterPanel;
    bool iscrafterPanelOn;

    private void Start()
    {
        crafterPanel.SetActive(false);
    }

    public void Open_CloseCrafterPanel()
    {
        iscrafterPanelOn = !iscrafterPanelOn;
        crafterPanel.SetActive(iscrafterPanelOn);
    }
}
