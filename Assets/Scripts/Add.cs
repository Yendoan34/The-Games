using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
// This script is used to add the bought items to the amount of weapons
public class Add : MonoBehaviour
{
    int brushAdded;
    int dryerAdded;
    int nailAdded;
    int rollAdded;
    // Start is called before the first frame update
    void Start()
    {
        // Get bought amount
        brushAdded = PlayerPrefs.GetInt("Added Brush", 0);
        dryerAdded = PlayerPrefs.GetInt("Added Dryer", 0);
        nailAdded = PlayerPrefs.GetInt("Added Nail", 0);
        rollAdded = PlayerPrefs.GetInt("Added Roll", 0);
        Adding();
    }
    private void Adding()
    {
        LimitedButtonClick click = gameObject.GetComponent<LimitedButtonClick>(); // Find the script has the amount of time to add
        if (gameObject.name == "Brush")
        {
            click.maxClicks += brushAdded;
        }
        else if (gameObject.name == "Hair Dryer")
        {
            click.maxClicks += dryerAdded;
        }
        else if (gameObject.name == "Nail polish")
        {
            click.maxClicks += nailAdded;
        }
        else if (gameObject.name == "Hair Roll")
        {
            click.maxClicks += rollAdded;
        }
        else
        {
            click.maxClicks += 0;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
