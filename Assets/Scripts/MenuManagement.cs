using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuManagement : MonoBehaviour
{
    
    public void PlayGame()
    {
        SceneManager.LoadScene(0);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(3);
    }
    public void Victory()
    {
        SceneManager.LoadScene(1);
    }
    public void Defeat()
    {
        SceneManager.LoadScene(2);
    }
}
