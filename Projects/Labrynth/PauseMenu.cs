using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    [SerializeField] public GameObject panel;
    private PlayerController playercontroller;
    private bool isPaused;
    private void Awake()
    {
        panel.SetActive(false);//starts false for when restart game fix & normal time
        Time.timeScale = 1f;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))//when pressed escape than checks if its paused or else it resumes
        {
            if (isPaused)
            {
                Debug.Log("Paused");
                ResumeGame();
            }
            else
            {
                PauseGame();
                Debug.Log("Unpaused");
            }
        }
    }
    private void PauseGame()//everything for when paused,time is stopped, panel is actived, and curser lock for to stop moving camera 
    {
        panel.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        FindObjectOfType<PlayerController>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
    }
    private void ResumeGame()//panel is not active, time is normal, bool is false, and curser for camera is on locked mode
    {
        panel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        FindObjectOfType<PlayerController>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void ResumeGameButton()//for the button itself as extra option 
    {
        if (isPaused)
        {
            ResumeGame();
        }
    }
}
