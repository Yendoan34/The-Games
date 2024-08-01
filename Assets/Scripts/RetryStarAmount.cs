using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetryStarAmount : MonoBehaviour
{
    public GameObject fail;
    private int initialAmount;
    // Start is called before the first frame update
    void Start()
    {
        initialAmount = PlayerPrefs.GetInt("Score", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (fail.activeSelf)
        {
            PlayerPrefs.SetInt("Score", initialAmount);
            PlayerPrefs.Save(); // Make sure to call Save() to save the changes immediately
        }
    }

}
