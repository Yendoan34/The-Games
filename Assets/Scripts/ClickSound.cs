using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSound : MonoBehaviour
{
    // Start is called before the first frame update
    public void Click()
    {
        AudioManager.instance.PlaySound("Click");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
