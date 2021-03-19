﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //public GameObject options;

    public void NewGame()
    {
        SceneManager.LoadScene("Game");
    }


    public void ExitGame()
    {
        Application.Quit();
    }
}
