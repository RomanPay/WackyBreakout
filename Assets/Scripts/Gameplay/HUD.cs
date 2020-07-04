using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] private Text score;
    [SerializeField] private Text ballsLeft;
    private int _score = 0;

    private static int _ballLeft;
    
    private string _prefixScoreText;
    private string _prefixBallLeftText;
    private void Start()
    {
        _prefixBallLeftText = "x";
        _ballLeft = ConfigurationUtils.NumberBalls;
        ballsLeft.text = _prefixBallLeftText + _ballLeft;
        
        _prefixScoreText = "Score ";
        score.text = _prefixScoreText + _score;
    }

    public void IncreaseBalls()
    {
        if (_ballLeft > 0)
            _ballLeft--;
        ballsLeft.text = _prefixBallLeftText + _ballLeft;
    }
    public void AddScorePoints(int points)
    {
        _score += points;
        score.text = _prefixScoreText + _score;
    }
    
}
