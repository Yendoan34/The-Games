using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Guide : MonoBehaviour
{
    public GameObject arrow1;
    public GameObject arrow2;
    public GameObject arrow3;
    TextMeshProUGUI guideText;
    private bool showed = false;
    private bool clicked = false;
    // Start is called before the first frame update
    void Start()
    {
        guideText = GameObject.Find("GuideText").GetComponent<TextMeshProUGUI>();
        guideText.text = ("Hover at the upper area");
        PauseGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (!arrow1.activeSelf && !showed)
        {
            arrow2.SetActive(true);
            guideText.text = ("Click to choose weapon");
            showed = true;
            ResumeGame();
        }
    }
    void OnMouseOver()
    {
        arrow1.SetActive(false);
    }
    void PauseGame()
    {
        Time.timeScale = 0; // Pause the game
    }

    void ResumeGame()
    {
        Time.timeScale = 1; // Resume the game
    }
    public void Next()
    {
        if (!clicked)
        {
            arrow2.SetActive(false);
            arrow3.SetActive(true);
            guideText.text = ("Choose a target position to place the weapon");
            clicked = true;
        }
    }
}
