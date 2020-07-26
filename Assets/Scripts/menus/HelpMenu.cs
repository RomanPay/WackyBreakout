using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HelpMenu : MonoBehaviour
{
    public void CloseWindow()
    {
        AudioManager.Play(AudioClipName.ClickButton);
        SceneManager.LoadScene("Scenes/MainMenu");
        Destroy(gameObject);
    }
}
