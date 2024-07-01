using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour
{
    public GameObject enemy; // Prefab of the enemy to spawn
    public float spawnRate = 2f; // Rate at which enemies will spawn
    public int maxEnemies = 1; // Maximum number of enemies to spawn
    public GameObject nextButton;
    private bool stop = false;
    private GameObject[] enemies;
    private int enemiesSpawned = 0; // Counter for the number of spawned enemies
    void Start()
    {
        enemies = new GameObject[maxEnemies]; // Initialize the array
        // Start spawning enemies
        InvokeRepeating("SpawnEnemy", 2f, spawnRate);
    }
    void Update()
    {
        if (stop==true)
        {
            if (CountAliveEnemies() == 0) // Check if all enemies are destroyed
            {
                nextButton.SetActive(true);
            }
        }
    }
    void SpawnEnemy()
    {
        if (enemiesSpawned < maxEnemies)
        {
            // Spawn enemy at the position of the spawn point
            GameObject newEnemy = Instantiate(enemy, transform.position, Quaternion.identity);
            newEnemy.SetActive(true); // Ensure the spawned enemy is enabled
            enemies[enemiesSpawned] = newEnemy; // Add the spawned enemy to the array
            enemiesSpawned++;
        }
        else
        {
            stop = true;
            // Stop spawning when the limit is reached
            CancelInvoke("SpawnEnemy");
        }
    }
    // Function to count alive enemies
    int CountAliveEnemies()
    {
        int count = 0;
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] != null) // Check if the enemy is not destroyed
            {
                count++;
            }
        }
        return count;
    }
}
