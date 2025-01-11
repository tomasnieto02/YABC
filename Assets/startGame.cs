using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startGame : MonoBehaviour
{
    public void gameStart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainGame");
    }
}
