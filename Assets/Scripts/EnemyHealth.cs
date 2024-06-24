using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 3;
    public int maxHealth;
    public GameObject enemy;
    public GameObject star;
    public Transform dropPoint;
    // Start is called before the first frame update
    void Start()
    {
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
            health--;
            if (health <= 0)
            {
                AudioManager.instance.PlaySound("Magic");
                GameObject point = Instantiate(star, dropPoint.position, Quaternion.identity);
                Destroy(enemy);
            }
            Destroy(collision.gameObject);
        }
    }
}
