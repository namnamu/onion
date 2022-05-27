using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void MainToPlay()
    {
        SceneManager.LoadScene("Play1");
    }

    public void PlayToMain()
    {
        SceneManager.LoadScene("Main");
    }

    public void Skip()
    {
        SceneManager.LoadScene("Main");
    }

    public void MainToLogin()
    {
        SceneManager.LoadScene("WebLogin");
    }

    public void GameExit()
    {
        // GameExit
        Application.Quit();
    }
    public void Reroad()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
