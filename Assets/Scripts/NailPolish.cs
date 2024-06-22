using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class NailPolish : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (collision != null)
            {
                
            }
        }
    }
    private IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(3f); // Adjust the delay as needed
        Destroy(gameObject); // Destroy the game object
    }
}
