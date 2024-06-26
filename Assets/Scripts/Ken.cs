using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ken : MonoBehaviour
{
    private float elapsedTime = 0f;
    private bool isDestroying = true;
    private Animator ken;
    public GameObject star;
    void Start()
    {
        ken = GetComponent<Animator>(); // Get the Animator component
        ken.SetTrigger("Ken Fire");
        AudioManager.instance.PlaySound("Magic");
    }
    // Update is called once per frame
    void Update()
    {
        // Update the elapsed time
        elapsedTime += Time.deltaTime;

        // If the elapsed time is less than or equal to 4 seconds, continue destroying enemies
        if (elapsedTime <= 4f && isDestroying)
        {
            DestroyAllEnemies();
        }
        else
        {
            // After 4 seconds, stop destroying enemies
            isDestroying = false;
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
            GameObject point = Instantiate(star, enemy.transform.position, Quaternion.identity);
            Destroy(enemy);
        }
    }
}
