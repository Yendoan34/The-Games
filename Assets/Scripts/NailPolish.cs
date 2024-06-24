using System.Collections;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class NailPolish : MonoBehaviour
{
    private float timer = 0.0f;
    private bool enemyHit = false;
    private Transform enemyTransform;
    private Vector3 originalPosition;
    private float moveDistance = -0.8f; // Distance to move the enemy to the left
    private Vector3 targetPosition;
    private float moveTimer = 0.0f;
    private float moveDuration = 0.8f; // Duration for moving the enemy
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (collision != null)
            {
                enemyTransform = collision.GetComponent<Transform>();
                Enemy enemy = collision.GetComponentInParent<Enemy>();
                if (enemyTransform != null)
                {
                    Debug.Log("Enemy hit");
                    AudioManager.instance.PlaySound("Nail Polish");
                    enemyHit = true; // Set the flag to true
                    originalPosition = enemyTransform.position; // Save the original position
                    targetPosition = originalPosition + new Vector3(moveDistance, 0, 0); // Calculate the target position
                    enemy.ApplyPush(Vector3.right, 0f, 3f);
                }
            }
        }
    }

    void Update()
    {
        if (enemyHit)
        {
            moveTimer += Time.deltaTime;
            if (moveTimer <= moveDuration)
            {
                // Move the enemy slightly towards the target position
                enemyTransform.position = Vector3.Lerp(originalPosition, targetPosition, moveTimer / moveDuration);
            }
            else
            {
                // Ensure the enemy is exactly at the target position
                enemyTransform.position = targetPosition;
            }
            timer += Time.deltaTime;
            Debug.Log(timer);

            if (timer >= 4f)
            {
                StartCoroutine(DestroyAfterDelay());
                enemyHit = false; // Reset the flag to avoid starting the coroutine multiple times
            }
        }
    }

    private IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(0.5f); // Adjust the delay as needed
        Destroy(gameObject); // Destroy the game object
    }
}
