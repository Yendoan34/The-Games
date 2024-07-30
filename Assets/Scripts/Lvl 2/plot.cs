using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plot : MonoBehaviour
{
    [SerializeField] SpriteRenderer sr;
    [SerializeField] Color hoverColor;

    GameObject tower;
    Color startColor;

    void Start()
    {
        startColor = sr.color;
    }

    void OnMouseEnter()
    {
        sr.color = hoverColor;
    }

    void OnMouseExit()
    {
        sr.color = startColor;
    }

    void OnMouseDown()
    {
        if (tower != null) return;

        Tower towerToBuild = BuildManager.main.GetSelectedTower();

        if (towerToBuild.cost > LevelManager.main.currency)
        {
            AudioManager.instance.PlaySound("Click");
            Debug.Log("can't afford a gun");
            return;
        }

        LevelManager.main.SpendCurrency(towerToBuild.cost);

        tower = Instantiate(towerToBuild.prefab, transform.position, Quaternion.identity);
        
    }
}
