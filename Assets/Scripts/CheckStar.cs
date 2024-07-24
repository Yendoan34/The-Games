using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class CheckStar : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    private int starAmount;
    // Start is called before the first frame update
    void Start()
    {
        starAmount = PlayerPrefs.GetInt("Score", 0);
        scoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        scoreText.text = ("Stars: " + starAmount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
