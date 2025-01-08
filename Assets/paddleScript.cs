using System;
using System.Collections;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float speed;
    public Vector2 paddlePos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.name = "Paddle";
    }

    // Update is called once per frame
    void Update()
    {
        bool left = Input.GetKey(KeyCode.A);
        bool right = Input.GetKey(KeyCode.D);
        if (left && transform.position.x > -8)
        {
            transform.Translate(Vector2.left * Time.deltaTime * speed);
        }
        else if (right && transform.position.x < 8)
        {
            transform.Translate(Vector2.right * Time.deltaTime *speed);
        }
        paddlePos = transform.position;
    }
}
