using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LimitedButtonClick : MonoBehaviour
{
    private int clickCount = 0;
    private int maxClicks = 3;
    private Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        clickCount++;
        if (clickCount >= maxClicks)
        {
            button.gameObject.SetActive(false); // Disable the button
        }
    }
}
