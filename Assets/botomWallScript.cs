using System;
using System.Collections;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.SceneManagement;

public class botomWallScript : MonoBehaviour
{
    public gameLogic logic;
    public ballScript ball;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<gameLogic>();
        ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<ballScript>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            // Decreases lives if there is a collision with the bottom of the screen.
            if (logic.lives > 0)
            {
                ball.playBall = false;
                logic.decreaseLive();
            }
            else
            // Game over if there's no lives left.
            {
                ball.playBall = false;
                SceneManager.LoadScene("GameOver"); 
            }
        }
    }
}
