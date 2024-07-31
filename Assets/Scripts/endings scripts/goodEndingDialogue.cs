using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class goodEndingDialogue : MonoBehaviour
{
    public GameObject[] objectsToToggle; // Array of GameObjects to toggle
    public Animator barbie;
    public Animator ken;
    private int currentIndex = 0; // Index of the currently active object

    public void Start()
    {
        barbie.SetTrigger("Talk");
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
            barbie.SetTrigger("Talk");
        }
        else if (currentIndex == 2)
        {
            ken.SetTrigger("Ken Talk");
        }
        else if (currentIndex == 4)
        {
            barbie.SetTrigger("Talk");
        }
        else if (currentIndex == 5)
        {
            LoadScene();
        }
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(16);
    }
}
