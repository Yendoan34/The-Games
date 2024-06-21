using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefabs;

    [SerializeField] int baseEnemies = 8;
    [SerializeField] float enemiesPerSecond = 0.5f;
    //[SerializeField] float timeBetweenWaves = 5f;
    [SerializeField] float difficultyScalingFactor = 0.75f;

    int currentWave = 1;
    int enemiesAlive;
    int enemiesLeftToSpawn;
    float timeSinceLastSpawn;
    bool isSpawning = false;

    void Start()
    {
        StartWave(); //muokkaa myöhemmin pieni tauko, ettei ala heti
    }

    void Update()
    {
        if (!isSpawning) return;

        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= (1f / enemiesPerSecond)) 
        {
            Debug.Log("Enemy :D");
            timeSinceLastSpawn = 0f;
        }
    }

    void StartWave() 
    {
        isSpawning = true;
        enemiesLeftToSpawn = EnemiesPerWave();
    }

    int EnemiesPerWave() 
    {
        return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currentWave, difficultyScalingFactor)); ;
    }
}
