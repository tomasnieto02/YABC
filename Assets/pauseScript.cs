using System.Data.Common;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class pauseScript : MonoBehaviour
{
    
    public static bool isPaused = false;
    public GameObject pauseUI;
    
    // Update is called once per frame
    void Update()
    {
        // Pauses or resumes the game when escape key is pressed.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    // Resumes game.
    public void Resume()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }

    // Pauses game.
    void Pause()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }
}
