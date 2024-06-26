using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AskKen : MonoBehaviour
{
    public GameObject ken;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ken.SetActive(true);
        }
    }
}
