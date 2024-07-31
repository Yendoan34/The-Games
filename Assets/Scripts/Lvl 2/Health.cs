using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth2 : MonoBehaviour
{
    [SerializeField] public int hitPoints = 2;
    [SerializeField] int currencyWorth = 1;

    public int maxHP;

    void Start()
    {
        maxHP = hitPoints;
    }

    bool isDestroyed = false;

    public void TakeDamage(int dmg)
    {
        hitPoints -= dmg;

        if (hitPoints <= 0 && !isDestroyed)
        {
            EnemySpawner.onEnemyDestroy.Invoke();
            LevelManager.main.IncreaseCurrency(currencyWorth); 
            isDestroyed = true;
            Destroy(gameObject);
        }
    }
}
