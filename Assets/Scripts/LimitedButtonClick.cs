using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LimitedButtonClick : MonoBehaviour
{
    private int clickCount = 0;
    public int maxClicks = 3;
    private Button button;
    private int time;
    TextMeshProUGUI timeText;
    void Start()
    {
        time = maxClicks - clickCount;
        timeText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        timeText.text = $"{time}";
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        clickCount++;
        time = maxClicks - clickCount;
        timeText.text = $"{time}";
        if (clickCount >= maxClicks)
        {
            button.gameObject.SetActive(false); // Disable the button
        }
    }
}
