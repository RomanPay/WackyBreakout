using System;
using UnityEngine;
using UnityEngine.Timeline;

public class PauseMenu : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 0;
    }

    /// <summary>
    /// Event from resume button
    /// </summary>
    public void ResumeButton()
    {
        Time.timeScale = 1;
        Destroy(gameObject);
    }
    
    /// <summary>
    /// Event from quit button
    /// </summary>
    public void QuitButton()
    {
        Time.timeScale = 1;
        Destroy(gameObject);
        MenuManager.GoToMenu(MenuName.MainMenu);
    }
}