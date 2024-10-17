using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _settings;
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _mainUI;
    
    
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenu ()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Settings()
    {
        _settings.SetActive(true);
        _pauseMenu.SetActive(false);
        _mainUI.SetActive(false);
    }

    public void Back()
    {
        _settings.SetActive(false);
        _pauseMenu.SetActive(true);
    }
}
