using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 3;
    public int maxHealth;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Respawn"))
        {
            AudioManager.instance.PlaySound("Hit");
            health--;
            if (health <= 0)
            {
                Destroy(enemy);
            }
            Destroy(collision.gameObject);
        }
    }
}
