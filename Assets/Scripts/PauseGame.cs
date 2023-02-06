using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public SettingsMenu setm;

    public bool settingsOpen;
    public bool gamePaused = false;

    public GameObject pauseMenu;
    public GameObject settingsMenu;

    public void pauseGame()
    {
        gamePaused = true;
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void unpauseGame()
    {
        gamePaused=false;
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void openSettings()
    {
        settingsMenu.SetActive(true);
        setm.settingsOpen = true;
        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && gamePaused == false)
        {   
            pauseGame();
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && gamePaused == true )
        {
            unpauseGame();
        }
    }
}
