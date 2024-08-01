using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairDryer : MonoBehaviour
{
    public LayerMask enemyLayer;
    public float rayDistance = 10f; // Set the distance for the raycast
    private float thrust = 0.005f;
    private float timer = 0.0f;
    private bool sound = false;
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
            Enemy enemy = hit.collider.GetComponentInParent<Enemy>();
            if (enemy != null)
            {
                Debug.Log("Enemy hit");
                if (!sound)
                {
                    AudioManager.instance.PlaySound("Hair Dryer");
                    sound = true;
                }

                // Apply push to the enemy
                enemy.ApplyPush(Vector3.right, thrust, 4f);

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
