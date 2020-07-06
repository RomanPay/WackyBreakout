using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    #region Fields

    // score support
    private static Text _scoreText;
    private static int _score = 0;
    private const string PrefixScoreText = "Score: ";

    // balls left support
    private static Text _ballsLefText;
    private static int _ballsLeft;
    private const string PrefixBallLeftText = "x";

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
    }

    #region Public methods

    /// <summary>
    /// Updates the balls left
    /// </summary>
    public static void DecreaseBalls()
    {
        if (_ballsLeft > 0)
            _ballsLeft--;
        _ballsLefText.text = PrefixBallLeftText + _ballsLeft;
    }

    /// <summary>
    /// Updates score
    /// </summary>
    /// <param name="points">points to add</param>
    public static void AddScorePoints(int points)
    {
        _score += points;
        _scoreText.text = PrefixScoreText + _score;
    }

    #endregion
}
