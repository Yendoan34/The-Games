using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateKen : MonoBehaviour
{
    bool hasBeenUsed = false;

    public GameObject ken;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !hasBeenUsed)
        {
            ken.SetActive(true);
            hasBeenUsed = true;
        }
    }
}
