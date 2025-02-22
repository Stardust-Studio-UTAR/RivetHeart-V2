﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public Button pauseButton;
    public Button map;
    public Button inventory;
    public Button descriptionBackground;

    ///[SerializeField]
    private bool paused;
    private bool openmap;
    private bool openInventory;
    private bool openDescriptionBackground;

    // Start is called before the first frame update
    void Start()
    {
        paused = false;
        openmap = false;
        openInventory = false;
        openDescriptionBackground = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
            {
                paused = true;
                Time.timeScale = 0;
                DisplayButtonPause();
            }
            else
            {
                paused = false;
                Time.timeScale = 1;
                HideButtonPause();
            }
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            if (!openmap)
            {
                openmap = true;
                DisplayButtonMap();
            }
            else
            {
                openmap = false;
                HideButtonMap();
            }
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!openInventory)
            {
                openInventory = true;
                DisplayButtonInventory();
            }
            else
            {
                openInventory = false;
                HideButtonInventory();
            }
        }
    }

    public void DisplayButtonPause()
    {
        pauseButton.gameObject.SetActive(true);
    }

    public void HideButtonPause()
    {
        pauseButton.gameObject.SetActive(false);
    }


    public void DisplayButtonMap()
    {
        map.gameObject.SetActive(true);
    }

    public void HideButtonMap()
    {
        map.gameObject.SetActive(false);
    }

    public void DisplayButtonInventory()
    {
        inventory.gameObject.SetActive(true);
    }

    public void HideButtonInventory()
    {
        inventory.gameObject.SetActive(false);
    }

    public void DisplayButtonDescriptionBackground()
    {
        descriptionBackground.gameObject.SetActive(true);
    }

    public void HideButtonDescriptionBackground()
    {
        descriptionBackground.gameObject.SetActive(false);
    }

    public void ButtonQuitToMenu()    //quit to menu
    {
        SceneManager.LoadScene("Menu");
    }

    public void ButtonStart()
    {
        SceneManager.LoadScene("MainGame");  //load the scene, the scene(1) is manage from unity.
    }

    public void ButtonCredit()    //quit to menu
    {
        SceneManager.LoadScene("Credit"); //load the scene, the scene(1) is manage from unity.
    }

    public void ButtonQuitGame()    //quit game
    {
        Application.Quit();
        Debug.Log("QuitGame");
    }
}
