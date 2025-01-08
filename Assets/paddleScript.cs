using System;
using System.Collections;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // Variable for controlling the paddle's speed.
    public float paddleSpeed;
    // Variable for storing the paddle's current psoition.
    public Vector2 paddlePos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created.
    void Start()
    {
        gameObject.name = "Paddle";
    }

    // Update is called once per frame.
    void Update()
    {
        bool left = Input.GetKey(KeyCode.A);
        bool right = Input.GetKey(KeyCode.D);
        // Paddle controls. If A is pressed on the keyborad, paddle will move to the left. If the paddle reaches the leftmost side of the screen, the paddle won't move any further.
        if (left && transform.position.x > -8)
        {
            transform.Translate(Vector2.left * Time.deltaTime * paddleSpeed);
        }
        // Paddle controls. If D is pressed on the keyborad, paddle will move to the right. If the paddle reaches the righttmost side of the screen, the paddle won't move any further.
        else if (right && transform.position.x < 8)
        {
            transform.Translate(Vector2.right * Time.deltaTime *paddleSpeed);
        }
        // Paddle's current position is stored in this public variable which is accesed by the Ball class.
        paddlePos = transform.position;
    }
}
