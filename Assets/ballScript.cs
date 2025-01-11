using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ballScript : MonoBehaviour
{
    // Bool variable for knowing if there is a ball currently in play.
    public bool playBall = false;
    // Variable for setting an offset to the paddle when the ball isn't in play.
    public float ballOnPadOffset;
    // Variable for controlling the ball's speed.
    public float ballSpeed;
    // Variable for calculating the ball's direction when it bounces on the paddle.
    public float newDirFactor;
    // Keeps track of how many blocks are left.
    private int currentBricks = 80;
    private AudioSource sfx;
    public gameLogic logic;
    // Vector for moving the ball in a direction.
    Vector2 direction;
    // Reference for accesing paddleScript's variables.
    [SerializeField] private Paddle paddleScript;
    // Ball's rigid body.
    public Rigidbody2D ballRb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created.
    void Start()
    {
        gameObject.name = "Ball";
        ballRb = GetComponent<Rigidbody2D>();
        // Gets a normalized direction for the ball's movement.
        direction = Vector2.one.normalized;
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<gameLogic>();
        sfx = GetComponent<AudioSource>();
    }

    // Update is called once per frame.
    void Update()
    {
        // Shoots the ball when the space bar is pressed and there isn't a ball in play.
        if (Input.GetKeyDown(KeyCode.Space) && !playBall)
        {
            playBall = true;
            ballRb.linearVelocity = direction * ballSpeed;
        }
        // Attaches the ball on top of the paddle if the ball is not in play.
        if (!playBall)
        {
            transform.position = paddleScript.paddlePos + (Vector2.up * ballOnPadOffset);
        }
        // Win condition.
        if (currentBricks == 0)
        {
            SceneManager.LoadScene("Win");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (playBall)
        {
            if (collision.gameObject.CompareTag("Paddle"))
            {
                // Gets the paddle's half width.
                float halfPaddle = collision.collider.bounds.size.x;
                // Calculates how far the point of collision is from the paddle's half.
                float x = (transform.position.x - collision.transform.position.x) / halfPaddle;
                // Calculates the direction of the ball upon colliding with the paddle.
                direction = new(newDirFactor * x, 1);
                direction = direction.normalized;
                // Mantains the ball's current velocity upon bouncing on the paddle.
                float currentBallSpeed = ballRb.linearVelocity.magnitude;
                ballRb.linearVelocity = direction * currentBallSpeed;
            }
            // Each type of brick adds a different amount of points to the overall score.
            else if (collision.gameObject.CompareTag("Blue Brick"))
            {
                Destroy(collision.gameObject);
                logic.addScore(50);
                currentBricks--;
            }
            else if (collision.gameObject.CompareTag("Yellow Brick"))
            {
                Destroy(collision.gameObject);
                logic.addScore(100);
                currentBricks--;
            }
            else if (collision.gameObject.CompareTag("Orange Brick"))
            {
                Destroy(collision.gameObject);
                logic.addScore(200);
                currentBricks--;
            }
            else if (collision.gameObject.CompareTag("Red Brick"))
            {
                Destroy(collision.gameObject);
                logic.addScore(300);
                currentBricks--;
            }
            sfx.Play();
        }
    }
}

