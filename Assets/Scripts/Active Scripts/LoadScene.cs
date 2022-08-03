using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("TestScene");

    }

    public void Instructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
     public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }

}
