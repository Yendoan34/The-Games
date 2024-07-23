using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerChecker : MonoBehaviour
{
    private void Awake()
    {
        if (AudioManager.instance != null && AudioManager.instance != FindObjectOfType<AudioManager>())
        {
            Destroy(FindObjectOfType<AudioManager>().gameObject);
        }
    }
}
