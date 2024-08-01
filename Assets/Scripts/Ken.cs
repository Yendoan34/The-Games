using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ken : MonoBehaviour
{
    private float elapsedTime = 0f;
    public GameObject star;
    private CountEnemy passed;
    void Start()
    {
        passed = GameObject.Find("Manager").GetComponent<CountEnemy>();
        AudioManager.instance.PlaySound("Magic");
        DestroyAllEnemies();
    }
    // Update is called once per frame
    void Update()
    {
        // Update the elapsed time
        elapsedTime += Time.deltaTime;

        // Destroy Ken after 2 seconds
        if (elapsedTime > 2f)
        {
            Destroy(gameObject);
        }
    }
    void DestroyAllEnemies()
    {
        // Find all game objects with the tag "Enemy"
        EnemyHealth[] enemies = GameObject.FindObjectsOfType<EnemyHealth>();

        // Destroy each enemy game object
        foreach (EnemyHealth enemy in enemies)
        {
            passed.dieEnemy++;
            GameObject point = Instantiate(star, enemy.transform.position, Quaternion.identity);
            Destroy(enemy.transform.parent.gameObject);
            
        }
    }
}
