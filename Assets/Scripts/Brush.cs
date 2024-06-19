using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brush : MonoBehaviour
{
    public GameObject spike;
    public Transform shootPoint;
    public int shootSpeed = 10;
    public float fireRate = 1f; // Time between shots
    public float spikeAmount = 4f;
    private float fireCountdown = 0f; // Countdown to the next shot
    private int projectilesFired = 0; // Counter for the projectiles fired
    // Start is called before the first frame update
    void Start()
    {
        fireCountdown = 1f / fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (fireCountdown <= 0f && projectilesFired < spikeAmount)
        {
            // Start the coroutine to move the projectile to the target position
            StartCoroutine(MoveProjectile());
            fireCountdown = 1f / fireRate;
            projectilesFired++; // Increment the counter
            // Check if we have fired the maximum number of projectiles
            if (projectilesFired >= spikeAmount)
            {
                StartCoroutine(DestroyAfterDelay()); // Destroy the game object
            }
        }

        fireCountdown -= Time.deltaTime;

    }
    private IEnumerator MoveProjectile()
    {
        // Instantiate the projectile at the shoot point
        GameObject projectile = Instantiate(spike, shootPoint.position, Quaternion.identity);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        // Disable gravity and other physics interactions while moving
        if (rb != null)
        {
            rb.isKinematic = true;
        }

        while (projectile != null)
        {
            // Calculate the step size based on shootSpeed and deltaTime
            float step = shootSpeed * Time.deltaTime;
            projectile.transform.position += new Vector3(step, 0, 0);

            yield return null; // Wait until the next frame
        }
    }
    private IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(1.5f); // Adjust the delay as needed
        Destroy(gameObject); // Destroy the game object
    }
}
