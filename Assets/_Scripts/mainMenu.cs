using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMenu : MonoBehaviour {

    [Header("Menu Panels")]
    public GameObject menuMain;
    public GameObject MPSelectionMenu;
    public GameObject OptionsMenu;
    public GameObject ColorPickerMenu;
    public GameObject OnlinePlayMenu;
    [Space(10)]
    [Header("Networking Stuff")]
    public GameObject Launcher;


    private void Awake()
    {
        menuMain.SetActive(true);
        MPSelectionMenu.SetActive(false);
        OptionsMenu.SetActive(false);
        ColorPickerMenu.SetActive(false);
        OnlinePlayMenu.SetActive(false);
    }


    public void singlePlayerButtonClick()
    {
        Debug.Log("Disabled - Single Player Button");
    }

    public void multiPlayerButtonClick()
    {
        menuMain.SetActive(false);
        MPSelectionMenu.SetActive(true);
    }
    public void multiSelectionBackButtonClick()
    {
        MPSelectionMenu.SetActive(false);
        menuMain.SetActive(true);
    }


    public void offlinePlayButtonClick()
    {
        Debug.Log("Disabled - Offline Multiplayer Button");
    }
    public void onlinePlayButtonClick()
    {
        MPSelectionMenu.SetActive(false);
        Launcher.GetComponent<Launcher>().Connect();
    }
    public void onlineBackButtonClick()
    {
        OnlinePlayMenu.SetActive(false);
        MPSelectionMenu.SetActive(true);
    }

    public void optionsButtonClick()
    {
        menuMain.SetActive(false);
        OptionsMenu.SetActive(true);
    }
    public void optionsBackButtonClick()
    {
        OptionsMenu.SetActive(false);
        menuMain.SetActive(true);
    }

    public void colorPickerButtonClick()
    {
        menuMain.SetActive(false);
        ColorPickerMenu.SetActive(true);
    }

    public void exitButtonClick()
    {
        Application.Quit();
    }
}
