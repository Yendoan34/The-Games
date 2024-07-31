using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class LevelManager : MonoBehaviour
{
    public static LevelManager main;

    public Transform startPoint;
    public Transform[] path;

    public int currency;
    [SerializeField] static int currencyScore = 3;
    void Awake()
    {
        main = this;
    }

    void Start()
    {
        currency = 3;
        currencyScore = PlayerPrefs.GetInt("Score", 0);
    }

    public void IncreaseCurrency(int amount)
    {
        currency += amount;
        currencyScore = currency;
        SaveScore();
    }

    public bool SpendCurrency(int amount)
    {
        if (amount <= currency) 
        { 
            currency -= amount;
            currencyScore = currency;
            SaveScore();
            return true;
        }
        else  
        {
            Debug.Log("ei tarpeeks ostamaan mitää");
            return false;
        }
    }
    public void Raise()
    {
        currency++;
        currencyScore = currency;
        SaveScore();
    }
    private void SaveScore()
    {
        // Save the score to PlayerPrefs
        PlayerPrefs.SetInt("Score", currencyScore);
        PlayerPrefs.Save(); // Make sure to call Save() to save the changes immediately
    }

    public void ResetScore()
    {
        currencyScore = 0;
        SaveScore(); // Save the reset score to PlayerPrefs
    }
}
