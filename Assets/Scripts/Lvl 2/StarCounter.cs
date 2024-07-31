using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StarCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI currencyUI;
    [SerializeField] Animator anim;

    bool isMenuOpen = true; //on auki automaattisesti aluksi

    public void ToggleMenu()
    {
        isMenuOpen = !isMenuOpen;
        anim.SetBool("menuOpen", isMenuOpen);
    }

    void OnGUI()
    {
        currencyUI.text = LevelManager.main.currency.ToString();
    }
}
