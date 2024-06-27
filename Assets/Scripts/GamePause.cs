using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Pause the game when pressing Esc
public class GamePause : MonoBehaviour
{
    public GameObject instruction;
    private bool isPaused = false;
    
    // Update is called once per frame
    void Update()
    {
        // Check for the pause input (e.g., pressing the "P" key)
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    void PauseGame()
    {
        Time.timeScale = 0; // Pause the game
        isPaused = true;
        instruction.SetActive(true); // Show Instructions 
        AudioManager.instance.PauseMusic(); // Pause music
    }

    void ResumeGame()
    {
        Time.timeScale = 1; // Resume the game
        isPaused = false;
        instruction.SetActive(false); // close Instructions
        AudioManager.instance.ResumeMusic(); // Resume music
    }
}
