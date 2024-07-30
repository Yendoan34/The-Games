using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager main;

    public Transform startPoint;
    public Transform[] path;

    public int currency;

    void Awake()
    {
        main = this;
    }

    void Start()
    {
        currency = 3;
    }

    public void IncreaseCurrency(int amount)
    {
        currency += amount;
    }

    public bool SpendCurrency(int amount)
    {
        if (amount <= currency) 
        { 
            currency -= amount;
            return true;
        }
        else  
        {
            Debug.Log("ei tarpeeks ostamaan mit��");
            return false;
        }
    }
}
