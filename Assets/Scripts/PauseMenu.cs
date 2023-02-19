using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public string levelName;
    public GameObject pauseMenu;
    public bool isOn = false;

    public void Update()
    {
        if (Input.GetKey(KeyCode.Escape) || (Input.GetKeyDown(KeyCode.P)) && isOn == false) 
        {
            ToggleMenuOn();
        }
        else if(Input.GetKey(KeyCode.Escape) || (Input.GetKeyDown(KeyCode.P)) && isOn == true)
        {
            ToggleMenuOff();
        }
    }

    public void Exit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(levelName);
    }

    public void ToggleMenuOn()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isOn = true;
    }

    public void ToggleMenuOff()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isOn = false;
    }
}
