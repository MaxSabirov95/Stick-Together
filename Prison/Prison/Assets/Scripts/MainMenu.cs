using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject settings;
    public GameObject credits;
    public bool isMainMenu;

    public void NewGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Settings()
    {
        isMainMenu = !isMainMenu;
        mainMenu.SetActive(isMainMenu);
        settings.SetActive(!isMainMenu);
    }

    public void Credits()
    {
        isMainMenu = !isMainMenu;
        mainMenu.SetActive(isMainMenu);
        credits.SetActive(!isMainMenu);
    }
}
