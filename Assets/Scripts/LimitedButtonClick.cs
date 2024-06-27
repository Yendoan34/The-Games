using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
// Script to limit the time to click the button has this script
public class LimitedButtonClick : MonoBehaviour
{
    private int clickCount = 0;
    public int maxClicks = 3;
    private Button button;
    private int time; // amount of time that can click, show at the button
    TextMeshProUGUI timeText;
    void Start()
    {
        time = maxClicks - clickCount; // Get the amount at the beginning
        timeText = gameObject.GetComponentInChildren<TextMeshProUGUI>(); // Find the text to show "time"
        timeText.text = $"{time}"; // show "time"
        button = GetComponent<Button>(); // Get the Button component
        button.onClick.AddListener(OnButtonClick); // Add a click event to track when the button is clicked
    }

    void OnButtonClick()
    {
        clickCount++; // Increase 1 when button is clicked
        time = maxClicks - clickCount; // Update the time amount after clicked 1 time
        timeText.text = $"{time}"; // Update the text
        if (clickCount >= maxClicks)
        {
            button.gameObject.SetActive(false); // Disable the button if run out of time
        }
    }
}
