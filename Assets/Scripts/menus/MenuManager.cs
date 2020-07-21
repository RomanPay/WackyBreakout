using UnityEngine;
using UnityEngine.SceneManagement;

public static class MenuManager
{
    public static void GoToMenu(MenuName name)
    {
        switch (name)
        {
            case MenuName.MainMenu:
                SceneManager.LoadScene("Scenes/MainMenu");
                break;
            case MenuName.PauseMenu:
                Object.Instantiate(Resources.Load("PauseMenu"));
                break;
        }
    }
}