using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
// when hover at the upper area of the screen, the choices of weapons will be showed
public class Choices : MonoBehaviour
{
    public GameObject choices;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnMouseOver()
    {
        choices.SetActive(true);
    }
    void OnMouseExit()
    {
        choices.SetActive(false);
    }
}
