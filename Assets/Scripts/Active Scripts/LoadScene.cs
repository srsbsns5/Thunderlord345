using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("TestScene");
        Time.timeScale = 1f;

    }

    public void Instructions()
    {
        SceneManager.LoadScene("Instructions");
        Time.timeScale = 1f;
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
        Time.timeScale = 1f;
    }
     public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }

}
