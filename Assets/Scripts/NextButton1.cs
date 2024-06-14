using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextButton1 : MonoBehaviour
{
    public GameObject[] objectsToToggle; // Array of GameObjects to toggle
    public Animator barbie;
    public Animator ken;
    public Animator fairy;
    private int currentIndex = 0; // Index of the currently active object
    public void Start()
    {
        barbie.SetTrigger("Sad Talk");
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
            if (currentIndex == 7)
            {
                ken.SetTrigger("Ken Sad Talk");
            }
            else if (currentIndex%2 == 0)
            {
                barbie.SetTrigger("Sad Talk");
            }
            else
            {
                fairy.SetTrigger("Dark Fairy Talk");
            }
        }
        else
        {
            LoadScene();
        }
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(4);
    }
}
