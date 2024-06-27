using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        instruction.SetActive(true);
        AudioManager.instance.PauseMusic(); // Optional: Pause all sounds
        // Additional logic for pausing (e.g., show pause menu)
    }

    void ResumeGame()
    {
        Time.timeScale = 1; // Resume the game
        isPaused = false;
        instruction.SetActive(false);
        AudioManager.instance.ResumeMusic(); // Optional: Resume all sounds
        // Additional logic for resuming (e.g., hide pause menu)
    }
}
