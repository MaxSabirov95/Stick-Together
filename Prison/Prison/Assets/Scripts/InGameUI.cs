﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameUI : MonoBehaviour
{
    public GameObject crafterPanel;
    public GameObject pausePanel;
    public GameObject map;
    bool isCrafterPanelOn;
    bool isPauseMenuOn;
    bool isMapOn;

    private void Awake()
    {
        BlackBoard.inGameUI = this;
    }

    private void Start()
    {
        Time.timeScale = 1;
        crafterPanel.SetActive(isCrafterPanelOn);
        pausePanel.SetActive(isPauseMenuOn);
    }

    public void Open_CloseCrafterPanel()
    {
        isCrafterPanelOn = !isCrafterPanelOn;
        crafterPanel.SetActive(isCrafterPanelOn);
    }

    public void Map()
    {
        isMapOn = !isMapOn;
        map.SetActive(isMapOn);
    }

    public void PauseMenu()
    {
        isPauseMenuOn = !isPauseMenuOn;
        pausePanel.SetActive(isPauseMenuOn);
        if (isPauseMenuOn)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void Resume()
    {
        PauseMenu();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
