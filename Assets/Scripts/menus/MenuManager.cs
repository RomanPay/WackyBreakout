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
            case MenuName.HelpMenu:
                Object.Instantiate(Resources.Load("HelpMenu"));
                break;
            case MenuName.GameOverMenu:
                Object.Instantiate(Resources.Load("GameOverMenu"));
                break;
        }
    }
}