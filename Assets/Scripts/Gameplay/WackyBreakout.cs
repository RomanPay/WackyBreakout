using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WackyBreakout : MonoBehaviour
{
    private Text _text;
    private const string Score = "Score ";
    private int _numBlocks;

    private LastBlockDestroyed _lastBlockDestroyed;
    
    private void Start()
    {
        _lastBlockDestroyed = new LastBlockDestroyed();
        EventManager.LastBlockInvoker(this);
        
        EventManager.LastBallListener(FixScore);
        _numBlocks = GameObject.FindGameObjectsWithTag("Block").Length - 1;
        Debug.Log("on start " +_numBlocks);
        EventManager.BlockListener(CalcNumBlock);
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            AudioManager.Play(AudioClipName.ClickButton);
            MenuManager.GoToMenu(MenuName.PauseMenu);
        }
    }

    private void CalcNumBlock()
    {
        _numBlocks--;
        Debug.Log(_numBlocks);
        if (_numBlocks == 0)
        {
            _lastBlockDestroyed.Invoke();
            AudioManager.Play(AudioClipName.Win);
        }
    }
    
    private void FixScore(int score)
    {
        _text = GameObject.FindGameObjectWithTag("Finish").GetComponent<Text>();
        _text.text = Score + score;
    }

    public void LastBlockListener(UnityAction listener)
    {
        _lastBlockDestroyed.AddListener(listener);
    }
}
