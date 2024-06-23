using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWind : MonoBehaviour
{
    public LayerMask enemyLayer;
    public float rayDistance = 10f; // Set the distance for the raycast
    private TestEnemy rb;
    private float timer = 0.0f;
    private bool isEnemyStopped = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (!isEnemyStopped)
        {
            // Perform the raycast
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, rayDistance, enemyLayer);
            if (hit.collider != null)
            {
                rb = hit.collider.GetComponent<TestEnemy>();
                if (rb != null)
                {
                    AudioManager.instance.PlaySound("Hair Dryer");
                    rb.StopMovement();
                    isEnemyStopped = true;
                    timer += Time.deltaTime;
                }
            }
        }
        else
        {
            if (timer >= 4f)
            {
                if (rb != null)
                {
                    rb.ResumeMovement();
                }
                isEnemyStopped = false; // Reset the state
            }
        }
        
    }
    private IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(0.5f); // Adjust the delay as needed
        Destroy(gameObject); // Destroy the game object
    }

}
