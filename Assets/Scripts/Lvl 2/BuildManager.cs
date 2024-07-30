using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager main;

    //[SerializeField] GameObject[] towerPrefabs;
    [SerializeField] Tower[] towers;

    int selectedTower = 0;

    void Awake()
    {
        main = this;
    }

    public Tower GetSelectedTower()
    {
        return towers[selectedTower];
    }
}
