using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextButton : MonoBehaviour
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
        if (currentIndex < objectsToToggle.Length-1)
        {
            // Disable the current object
            objectsToToggle[currentIndex].SetActive(false);
            // Move to the next object
            currentIndex++;
            // Enable the next object
            objectsToToggle[currentIndex].SetActive(true);
            if (currentIndex == 4)
            {
                barbie.SetTrigger("Look");
                ken.SetTrigger("Ken Look");
            }
            else if (currentIndex == 2)
            {
                barbie.SetTrigger("Talk");
            }
            else
            {
                ken.SetTrigger("Ken Talk");
            }
        }
        else
        {
            LoadScene();
        }
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(2);
    }
}
