using UnityEngine;

public class Level1 : MonoBehaviour
{
    public GameObject fairy; // The fairy to spawn
    public GameObject teddy; // The teddy to spawn
    public GameObject fairy2; // The fairy2 to spawn
    public GameObject teddy2; // The teddy2 to spawn
    public float spawnRate = 4f; // Rate at which enemies will spawn
    public int maxEnemies = 8; // Maximum number of enemies to spawn
    public GameObject nextButton;
    public GameObject barbie;
    public GameObject fail;
    private bool stop = false;
    private GameObject[] enemies;
    private int enemiesSpawned = 0; // Counter for the number of spawned enemies
    private int fairySpawned = 0; // Counter for the number of spawned enemies
    private int teddySpawned = 0; // Counter for the number of spawned enemies
    private int fairy2Spawned = 0; // Counter for the number of spawned enemies
    private int teddy2Spawned = 0; // Counter for the number of spawned enemies
    public int passAmount = 3;
    private bool appearedbutton = false;
    private CountEnemy passed;
    void Start()
    {
        passed = GameObject.Find("Manager").GetComponent<CountEnemy>();
        enemies = new GameObject[maxEnemies]; // Initialize the array
        // Start spawning enemies
        InvokeRepeating("SpawnFairy", 2f, spawnRate);
        InvokeRepeating("SpawnTeddy", 5f, spawnRate);
        InvokeRepeating("SpawnFairy2", 15f, spawnRate);
        InvokeRepeating("SpawnTeddy2", 17f, spawnRate);
    }
    void Update()
    {
        if (stop==true)
        {
            if (CountAliveEnemies() == 0 && !appearedbutton) // Check if all enemies are destroyed
            {
                nextButton.SetActive(true);
                appearedbutton = true;
            }
            if ((passed.passEnemy + passed.dieEnemy) >= maxEnemies)
            {
                if (CountAliveEnemies() <= passAmount && !appearedbutton)
                {
                    nextButton.SetActive(true);
                    appearedbutton = true;
                }
                else if (!appearedbutton)
                {
                    barbie.SetActive(false);
                    fail.SetActive(true);
                    appearedbutton = true;
                }
            }
        }

    }
    void SpawnFairy()
    {
        if (fairySpawned < (maxEnemies/4 + 1) && enemiesSpawned < maxEnemies)
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
        if (teddySpawned < (maxEnemies/4 + 1) && enemiesSpawned < maxEnemies)
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
            
            // Stop spawning when the limit is reached
            CancelInvoke("SpawnTeddy");
        }
    }
    void SpawnFairy2()
    {
        if (fairy2Spawned < (maxEnemies / 4 + 1) && enemiesSpawned < maxEnemies)
        {
            // Spawn enemy at the position of the spawn point
            GameObject newEnemy = Instantiate(fairy2, transform.position, Quaternion.identity);
            newEnemy.SetActive(true); // Ensure the spawned enemy is enabled
            enemies[enemiesSpawned] = newEnemy; // Add the spawned enemy to the array
            enemiesSpawned++;
            fairy2Spawned++;
        }
        else
        {
            // Stop spawning when the limit is reached
            CancelInvoke("SpawnFairy");
        }
    }
    void SpawnTeddy2()
    {
        if (teddy2Spawned < (maxEnemies / 4 + 1) && enemiesSpawned < maxEnemies)
        {
            // Spawn enemy at the position of the spawn point
            GameObject newEnemy = Instantiate(teddy2, transform.position, Quaternion.identity);
            newEnemy.SetActive(true); // Ensure the spawned enemy is enabled
            enemies[enemiesSpawned] = newEnemy; // Add the spawned enemy to the array
            enemiesSpawned++;
            teddy2Spawned++;
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
