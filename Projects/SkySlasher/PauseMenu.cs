using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    public bool _paused;

    // gamestate reference
    public GameState CurrentState;
    void Update()
    {
        if (GameManager.Instance.CurrentState == GameState.PlayerInteraction)
        {
            GameManager.Instance.isPaused = true;
            return;
        }
        else
        {
            GameManager.Instance.isPaused = false;
        }
        //if pressed pause while paused
        if (Input.GetKeyDown(KeyCode.Escape) && _paused == true)
        {
            //unpause
            Time.timeScale = 1;
            _pauseMenu.SetActive(false);
            _paused = false;
        }
        //if press pause while unpaused
        else if(Input.GetKeyDown(KeyCode.Escape) && _paused == false)
        {
            //pause
            Time.timeScale = 0;
            _pauseMenu.SetActive(true);
            _paused = true;
        }
        if (!_pauseMenu.activeInHierarchy)
        {
            _paused = false;
        }
        else if (_pauseMenu.activeInHierarchy)
        {
            _paused = true;
        }
    }
}
