using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("Scenes/Gameplay");
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void HelpButton()
    {
        Object.Instantiate(Resources.Load("HelpMenu"));
    }
}
