using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameLogic : MonoBehaviour
{
    public int score;
    public Text scoreText;
    public Text livesText;
    public int lives = 3;

    // Adds score in the UI.
    public void addScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = score.ToString();
    }

    // Decreases lives in the UI.
    public void decreaseLive()
    {
        lives--;
        livesText.text = lives.ToString();
    }
}
