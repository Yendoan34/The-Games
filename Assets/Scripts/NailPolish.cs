using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NailPolish : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Rigidbody2D enemyRb = collision.GetComponent<Rigidbody2D>();

            if (enemyRb != null)
            {
                // Set the velocity of the enemy to zero
                enemyRb.velocity = Vector2.zero;
            }
        }
    }

}
