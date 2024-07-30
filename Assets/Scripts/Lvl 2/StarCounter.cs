using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StarCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI currencyUI;

    void OnGUI()
    {
        currencyUI.text = LevelManager.main.currency.ToString();
    }
}
