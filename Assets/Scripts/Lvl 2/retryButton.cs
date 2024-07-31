using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class retryButton : MonoBehaviour
{
    public void retry()
    {
        AudioManager.instance.PlaySound("Click");
        SceneManager.LoadScene(4);
    }
}
