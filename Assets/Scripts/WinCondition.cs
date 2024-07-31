using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    private int starAmount;
    public GameObject Next1button;
    public GameObject Next2button;
    // Start is called before the first frame update
    void Start()
    {
        starAmount = PlayerPrefs.GetInt("Score", 0);
        if ( starAmount > 20 )
        {
            Next1button.SetActive(true);
        }
        else
        {
            Next2button.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
