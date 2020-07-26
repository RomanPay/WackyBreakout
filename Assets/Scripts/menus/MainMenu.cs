using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayButton()
    {
        AudioManager.Play(AudioClipName.ClickButton);
        SceneManager.LoadScene("Scenes/Gameplay");
    }

    public void QuitButton()
    {
        AudioManager.Play(AudioClipName.ClickButton);
        Application.Quit();
    }

    public void HelpButton()
    {
        AudioManager.Play(AudioClipName.ClickButton);
        gameObject.SetActive(false);
        Object.Instantiate(Resources.Load("HelpMenu"));
    }
}
