using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class badEndingDialogue : MonoBehaviour
{
    public GameObject[] objectsToToggle; // Array of GameObjects to toggle
    public Animator teddy;
    private int currentIndex = 0; // Index of the currently active object

    public void Start()
    {
        teddy.SetTrigger("Teddy Talking");
    }

    public void OnNextButtonClick()
    {
        // If there are objects left to toggle
        if (currentIndex < objectsToToggle.Length - 1)
        {
            // Disable the current object
            objectsToToggle[currentIndex].SetActive(false);
            // Move to the next object
            currentIndex++;
            // Enable the next object
            objectsToToggle[currentIndex].SetActive(true);
        }

        if (currentIndex == 1)
        {
            teddy.SetTrigger("Teddy Talking");
        }
        else
        {
            LoadScene();
        }
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(8);
    }
}
