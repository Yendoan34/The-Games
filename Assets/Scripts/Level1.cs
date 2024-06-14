using UnityEngine;

public class Level1 : MonoBehaviour
{
    public GameObject fairy; // Prefab of the fairy to spawn
    public float spawnRate = 2f; // Rate at which enemies will spawn
    public int maxEnemies = 4; // Maximum number of enemies to spawn
    public GameObject passedPanel;
    private bool stop = false;
    private GameObject[] enemies;
    private int enemiesSpawned = 0; // Counter for the number of spawned enemies
    void Start()
    {
        enemies = new GameObject[maxEnemies]; // Initialize the array
        // Start spawning enemies
        InvokeRepeating("SpawnFairy", 2f, spawnRate);
    }
    void Update()
    {
        if (stop==true)
        {
            if (CountAliveEnemies() == 0) // Check if all enemies are destroyed
            {
                passedPanel.SetActive(true);
            }
        }
    }
    void SpawnFairy()
    {
        if (enemiesSpawned < maxEnemies)
        {
            // Spawn enemy at the position of the spawn point
            GameObject newEnemy = Instantiate(fairy, transform.position, Quaternion.identity);
            enemies[enemiesSpawned] = newEnemy; // Add the spawned enemy to the array
            enemiesSpawned++;
        }
        else
        {
            stop = true;
            // Stop spawning when the limit is reached
            CancelInvoke("SpawnFairy");
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
