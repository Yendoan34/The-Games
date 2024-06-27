using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Activate Ken when press Space key
public class AskKen : MonoBehaviour
{
    public GameObject ken;
    private bool asked;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !asked)
        {
            ken.SetActive(true);
            asked = true;
        }
    }
}
