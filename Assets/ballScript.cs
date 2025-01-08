using System;
using System.Collections;
using UnityEngine;

public class ballScript : MonoBehaviour
{
    public bool playBall = false;
    public float ballOnPadOffset;
    [SerializeField] private Paddle paddleScript;
    public Rigidbody2D ballRb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!playBall)
        {
            transform.position = paddleScript.paddlePos + (Vector2.up * ballOnPadOffset);
        }
    }
}
