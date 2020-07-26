using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

   private void Start()
   {
      Time.timeScale = 0;
   }
   
   public void QuitButton()
   {
      Time.timeScale = 1;
      Destroy(gameObject);
      SceneManager.LoadScene("MainMenu");
      AudioManager.Play(AudioClipName.ClickButton);
   }
}
