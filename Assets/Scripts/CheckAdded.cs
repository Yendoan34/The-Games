using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CheckAdded : MonoBehaviour
{
    TextMeshProUGUI brushText;
    TextMeshProUGUI dryerText;
    TextMeshProUGUI nailText;
    TextMeshProUGUI rollText;
    int brushAdded;
    int dryerAdded;
    int nailAdded;
    int rollAdded;
    // Start is called before the first frame update
    void Start()
    {
        brushAdded = PlayerPrefs.GetInt("Added Brush", 0);
        dryerAdded = PlayerPrefs.GetInt("Added Dryer", 0);
        nailAdded = PlayerPrefs.GetInt("Added Nail", 0);
        rollAdded = PlayerPrefs.GetInt("Added Roll", 0);
        brushText = GameObject.Find("BrushText").GetComponent<TextMeshProUGUI>();
        brushText.text = ("Bought brush: " + brushAdded);
        dryerText = GameObject.Find("DryerText").GetComponent<TextMeshProUGUI>();
        dryerText.text = ("Bought dryer: " + dryerAdded);
        nailText = GameObject.Find("NailText").GetComponent<TextMeshProUGUI>();
        nailText.text = ("Bought nail polish: " + nailAdded);
        rollText = GameObject.Find("RollText").GetComponent<TextMeshProUGUI>();
        rollText.text = ("Bought hair roll: " + rollAdded);
    }
    private void Adding()
    {
        LimitedButtonClick click = gameObject.GetComponent<LimitedButtonClick>();
        if (gameObject.name == "Brush")
        {
            click.maxClicks += brushAdded;
        }
        else if (gameObject.name == "Hair Dryer")
        {
            click.maxClicks += dryerAdded;
        }
        else if (gameObject.name == "Nail Polish")
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
