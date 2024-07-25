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
    private bool collected = false;
    // Start is called before the first frame update
    void Start()
    {
        CheckInitialMousePosition();
        guideText = GameObject.Find("GuideText").GetComponent<TextMeshProUGUI>();
        guideText.text = ("Hover at the upper area");
        PauseGame();
    }

    // Update is called once per frame
    void Update()
    {
        CheckInitialMousePosition();
        if (!arrow1.activeSelf && !showed)
        {
            arrow2.SetActive(true);
            guideText.text = ("Click to choose weapon");
            showed = true;
            ResumeGame();
        }
        PickUp star = (PickUp)FindObjectOfType(typeof(PickUp));
        if (star != null && !collected)
        {
            guideText.text = ("Collect the stars");
            collected = true;
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
    void CheckInitialMousePosition()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D collider2D = GetComponent<Collider2D>();

        if (collider2D != null && collider2D.OverlapPoint(mousePosition))
        {
            OnMouseOver();
        }
    }
}
