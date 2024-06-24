using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LostSound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.PlaySound("Loose");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
