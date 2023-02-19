using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryOption : MonoBehaviour
{
    public string MainManu;
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
    public void Menu()
    {
        SceneManager.LoadScene(MainManu);
        Time.timeScale = 1f;
    }
}
