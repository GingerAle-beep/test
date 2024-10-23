using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject canvas;//gameobject to put in the canvas from scene & and everying here switches to other scene or quit
    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("Main");
        Time.timeScale = 1f;
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void BackToEndScene()
    {
        SceneManager.LoadScene("Endmenu");
    }
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
