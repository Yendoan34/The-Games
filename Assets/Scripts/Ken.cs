using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ken : MonoBehaviour
{
    private float elapsedTime = 0f;
    public GameObject star;
    void Start()
    {
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
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // Destroy each enemy game object
        foreach (GameObject enemy in enemies)
        {
            // Check if the enemy is the root object or its parent does not have the "Enemy" tag
            if (enemy.transform.parent == null || enemy.transform.parent.tag != "Enemy")
            {
                GameObject point = Instantiate(star, enemy.transform.position, Quaternion.identity);
                Destroy(enemy);
            }
        }
    }
}
