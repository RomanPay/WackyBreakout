using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    #region Fields

    // score support
    private Text _scoreText;
    private int _score = 0;
    private const string PrefixScoreText = "Score: ";

    // balls left support
    private Text _ballsLefText;
    private int _ballsLeft;
    private const string PrefixBallLeftText = "x";

    private LastBallLostEvent _lastBall;

    #endregion

    private void Start()
    {
        // initialize score text
        _scoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Text>();
        _scoreText.text = PrefixScoreText + _score;
        
        // initialize balls left value and text
        _ballsLeft = ConfigurationUtils.NumberBalls;
        _ballsLefText = GameObject.FindGameObjectWithTag("BallsLeftText").GetComponent<Text>();
        _ballsLefText.text = PrefixBallLeftText + _ballsLeft;
        
        EventManager.AddPointsListener(AddScorePoints);
        EventManager.BallsLeftListeners(DecreaseBalls);
        EventManager.LastBlockListener(GameOver);
        
        _lastBall = new LastBallLostEvent();
        EventManager.LastBallInvoker(this);
    }

    #region Public methods

    /// <summary>
    /// Updates the balls left
    /// </summary>
    private void DecreaseBalls()
    {
        if (_ballsLeft > 0)
            _ballsLeft--;
        if (_ballsLeft == 0)
        {
           GameOver();
           AudioManager.Play(AudioClipName.Lose);
        }

        _ballsLefText.text = PrefixBallLeftText + _ballsLeft;
    }

    /// <summary>
    /// Updates score
    /// </summary>
    /// <param name="points">points to add</param>
    private void AddScorePoints(int points)
    {
        _score += points;
        _scoreText.text = PrefixScoreText + _score;
    }

    private void GameOver()
    {
        MenuManager.GoToMenu(MenuName.GameOverMenu);
        _lastBall.Invoke(_score);
    }
    
    public void LastBallAddListener(UnityAction<int> listener)
    {
        _lastBall.AddListener(listener);
    }

    #endregion
}
