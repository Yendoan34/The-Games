using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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
    public GameObject noTarget;
    private bool hasUpdated = false;
    private static LimitedButtonClick lastClickedButton; // Static reference to the last clicked button
    void Start()
    {
        time = maxClicks - clickCount; // Get the amount at the beginning
        timeText = gameObject.GetComponentInChildren<TextMeshProUGUI>(); // Find the text to show "time"
        timeText.text = $"{time}"; // show "time"
        button = GetComponent<Button>(); // Get the Button component
        button.onClick.AddListener(OnButtonClick); // Add a click event to track when the button is clicked
    }
    private void Update()
    {
        if (lastClickedButton == this && noTarget.activeSelf && !hasUpdated)
        {
            if (clickCount >= maxClicks)
            {
                this.button.interactable = true;
            }
            clickCount--; // Disable the last click because cannot find target
            time = maxClicks - clickCount; // Update the time amount
            timeText.text = $"{time}"; // Update the text
            hasUpdated = true;
        }
        // Reset the flag if the GameObject is disabled
        if (!noTarget.activeSelf)
        {
            hasUpdated = false;
        }
    }
    void OnButtonClick()
    {
        lastClickedButton = this; // Set this button as the last clicked button
        clickCount++; // Increase 1 when button is clicked
        time = maxClicks - clickCount; // Update the time amount after clicked 1 time
        timeText.text = $"{time}"; // Update the text
        if (clickCount >= maxClicks)
        {
            this.button.interactable = false;
        }
    }
}
