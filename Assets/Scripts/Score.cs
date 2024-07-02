using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Score : MonoBehaviour
{
    [SerializeField] static int addedBrush = 0;
    [SerializeField] static int addedDryer = 0;
    [SerializeField] static int addedNail = 0;
    [SerializeField] static int addedRoll = 0;
    TextMeshProUGUI starText;
    int score;
    // Start is called before the first frame update
    void Start()
    {
        score = PlayerPrefs.GetInt("Score", 0);
        ResetAdded();
        starText = GameObject.Find("StarAmountText").GetComponent<TextMeshProUGUI>();
        starText.text = ("Star amount: " + score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BuyBrush()
    {
        if (score >= 2)
        {
            score -= 2;
            addedBrush++;
            starText.text = ("Star amount: " + score);
            SaveScore();
            SaveAdded();
        }
        else
        {
            StartCoroutine(LackText());
        }
    }
    public void BuyDryer()
    {
        if (score >= 1)
        {
            score--;
            addedDryer++;
            starText.text = ("Star amount: " + score);
            SaveScore();
            SaveAdded();
        }
        else
        {
            StartCoroutine(LackText());
        }
    }
    public void BuyNail()
    {
        if (score >= 1)
        {
            score--;
            addedNail++;
            starText.text = ("Star amount: " + score);
            SaveScore();
            SaveAdded();
        }
        else
        {
            StartCoroutine(LackText());
        }
    }
    public void BuyRoll()
    {
        if (score >= 3)
        {
            score -= 3;
            addedRoll++;
            starText.text = ("Star amount: " + score);
            SaveScore();
            SaveAdded();
        }
        else
        {
            StartCoroutine(LackText());
        }
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
    private IEnumerator LackText()
    {
        starText.text = "Not enough star to buy.";
        yield return new WaitForSeconds(1f);
        starText.text = ("Star amount: " + score);
    }
    private void SaveAdded()
    {
        // Save the score to PlayerPrefs
        PlayerPrefs.SetInt("Added Brush", addedBrush);
        PlayerPrefs.SetInt("Added Dryer", addedDryer);
        PlayerPrefs.SetInt("Added Nail", addedNail);
        PlayerPrefs.SetInt("Added Roll", addedRoll);
        PlayerPrefs.Save(); // Make sure to call Save() to save the changes immediately
    }

    public void ResetAdded()
    {
        addedBrush = 0;
        addedDryer = 0;
        addedNail = 0;
        addedRoll = 0;
        SaveAdded(); // Save the reset score to PlayerPrefs
    }
}
