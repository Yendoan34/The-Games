using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairDryer : MonoBehaviour
{
    public LayerMask enemyLayer;
    public float rayDistance = 10f; // Set the distance for the raycast
    private Rigidbody2D rb;
    private float thrust = 0.005f;
    private float timer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        // Perform the raycast
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, rayDistance, enemyLayer);
        if (hit.collider != null)
        {
            Transform enemyTransform = hit.collider.GetComponent<Transform>();
            if (enemyTransform != null)
            {
                Debug.Log("Enemy hit");
                AudioManager.instance.PlaySound("Hair Dryer");

                // Move the enemy
                enemyTransform.position += new Vector3(thrust, 0, 0);
                timer += Time.deltaTime;
                Debug.Log(timer);

                if (timer >= 4f)
                {
                    StartCoroutine(DestroyAfterDelay());
                }
            }
        }
    }
    private IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(0.5f); // Adjust the delay as needed
        Destroy(gameObject); // Destroy the game object
    }

}
