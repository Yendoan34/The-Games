using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Manage enemy health
public class EnemyHealth : MonoBehaviour
{
    public int health = 3; // amount of health that enemy has
    public int maxHealth;
    public GameObject enemy;
    public GameObject star;
    public Transform dropPoint;
    private CountEnemy passed;
    // Start is called before the first frame update
    void Start()
    {
        passed = GameObject.Find("Manager").GetComponent<CountEnemy>();

        maxHealth = health;
        // Ignore collisions between enemy layers
        int enemyLayer = LayerMask.NameToLayer("Enemy");
        Physics2D.IgnoreLayerCollision(enemyLayer, enemyLayer, true);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Respawn"))
        {
            AudioManager.instance.PlaySound("Hit");
            health--; // decrease health when being shot
            if (health <= 0)
            {
                AudioManager.instance.PlaySound("Magic");
                GameObject point = Instantiate(star, dropPoint.position, Quaternion.identity); // drop a star for player to collect
                passed.dieEnemy++;
                Destroy(enemy); // Enemy dies when health is less than 0
            }
            Destroy(collision.gameObject); // destroy the bullet
        }
    }
}
