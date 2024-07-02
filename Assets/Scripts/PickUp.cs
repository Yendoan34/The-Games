using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UnityEngine.GraphicsBuffer;

public class PickUp : MonoBehaviour
{
    [SerializeField] static int score = 0;
    TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        score = PlayerPrefs.GetInt("Score", 0);
        scoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0; // Set z to 0 since we're in 2D

            // Find the closest target to the mouse position
            float distance = Vector3.Distance(mousePosition, transform.position);
            if (distance <= 0.1f)
            {
                Point();
            }
        }

    }
    public void Point()
    {
        score++;
        SaveScore(); // Save the score after incrementing
        scoreText.text = ("Stars: " + score);
        gameObject.SetActive(false);
    }
    private void SaveScore()
    {
        // Save the score to PlayerPrefs
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save(); // Make sure to call Save() to save the changes immediately
    }

    public void ResetScore()
    {
        score = 0;
        SaveScore(); // Save the reset score to PlayerPrefs
    }
}
