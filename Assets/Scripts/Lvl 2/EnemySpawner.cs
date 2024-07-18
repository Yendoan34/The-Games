using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefabs;

    [SerializeField] int baseEnemies = 8;
    [SerializeField] float enemiesPerSecond = 0.5f;
    [SerializeField] float timeBetweenWaves = 5f;
    [SerializeField] float difficultyScalingFactor = 0.75f;

    public static UnityEvent onEnemyDestroy = new UnityEvent();

    int currentWave = 1;
    int enemiesAlive;
    int enemiesLeftToSpawn;
    float timeSinceLastSpawn;
    bool isSpawning = false;

    void Awake()
    {
        onEnemyDestroy.AddListener(EnemyDestroyed);
    }

    void Start()
    {
        StartCoroutine(StartWave());
    }

    void Update()
    {
        if (!isSpawning) return;

        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= (1f / enemiesPerSecond) && enemiesLeftToSpawn > 0) 
        {
            SpawnEnemy();

            enemiesLeftToSpawn--;
            enemiesAlive++;
            timeSinceLastSpawn = 0f;
        }

        if (enemiesAlive == 0 && enemiesLeftToSpawn == 0)
        {
            EndWave();
        }
    }

    void EnemyDestroyed()
    {
        enemiesAlive--;
    }

    IEnumerator StartWave() 
    {
        yield return new WaitForSeconds(timeBetweenWaves);

        isSpawning = true;
        enemiesLeftToSpawn = EnemiesPerWave();
    }

    void EndWave()
    {
        isSpawning = false;
        timeSinceLastSpawn = 0f;
        currentWave++;
        StartCoroutine(StartWave());
    }

    void SpawnEnemy()
    {
        GameObject prefabToSpawn = enemyPrefabs[0];
        Instantiate(prefabToSpawn, LevelManager.main.startPoint.position, Quaternion.identity);
    }

    int EnemiesPerWave() 
    {
        return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currentWave, difficultyScalingFactor)); ;
    }
}
