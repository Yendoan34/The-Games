using UnityEngine;

public class Level1 : MonoBehaviour
{
    public GameObject fairy; // The fairy to spawn
    public GameObject teddy; // The teddy to spawn
    public float spawnRate = 4f; // Rate at which enemies will spawn
    public int maxEnemies = 8; // Maximum number of enemies to spawn
    public GameObject passedPanel;
    public GameObject barbie;
    private bool stop = false;
    private GameObject[] enemies;
    private int enemiesSpawned = 0; // Counter for the number of spawned enemies
    private int fairySpawned = 0; // Counter for the number of spawned enemies
    private int teddySpawned = 0; // Counter for the number of spawned enemies
    void Start()
    {
        enemies = new GameObject[maxEnemies]; // Initialize the array
        // Start spawning enemies
        InvokeRepeating("SpawnFairy", 2f, spawnRate);
        InvokeRepeating("SpawnTeddy", 5f, spawnRate);
    }
    void Update()
    {
        if (stop==true)
        {
            if (CountAliveEnemies() == 0) // Check if all enemies are destroyed
            {
                passedPanel.SetActive(true);
                AudioManager.instance.PlaySound("Passed");
            }
        }
    }
    void SpawnFairy()
    {
        if (fairySpawned < (maxEnemies/2 + 1) && enemiesSpawned < maxEnemies)
        {
            // Spawn enemy at the position of the spawn point
            GameObject newEnemy = Instantiate(fairy, transform.position, Quaternion.identity);
            newEnemy.SetActive(true); // Ensure the spawned enemy is enabled
            enemies[enemiesSpawned] = newEnemy; // Add the spawned enemy to the array
            enemiesSpawned++;
            fairySpawned++;
        }
        else
        {
            // Stop spawning when the limit is reached
            CancelInvoke("SpawnFairy");
        }
    }
    void SpawnTeddy()
    {
        if (teddySpawned < (maxEnemies/2 + 1) && enemiesSpawned < maxEnemies)
        {
            // Spawn enemy at the position of the spawn point
            GameObject newEnemy = Instantiate(teddy, transform.position, Quaternion.identity);
            newEnemy.SetActive(true); // Ensure the spawned enemy is enabled
            enemies[enemiesSpawned] = newEnemy; // Add the spawned enemy to the array
            enemiesSpawned++;
            teddySpawned++;
        }
        else
        {
            stop = true;
            // Stop spawning when the limit is reached
            CancelInvoke("SpawnTeddy");
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
        Debug.Log(count);
        return count;
    }
}
