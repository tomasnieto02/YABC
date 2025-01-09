using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startGame : MonoBehaviour
{
    public void gameStart()
    {
        SceneManager.LoadScene("MainGame");
    }
}
