using System.Collections;
using UnityEngine;
public class Player : MonoBehaviour
{
    public int shootspeed = 10;
    public GameObject gun;
    public GameObject[] projectiles; // Array to hold different projectiles
    public Transform shootPoint;
    public Transform[] target;
    private int currentProjectile = 0; // Index to keep track of current projectile type
    private Animator animator; // Reference to the Animator component

    void Start()
    {
        animator = GetComponent<Animator>(); // Get the Animator component
    }
    public void Shoot()
    {
        for (int i = 0; i < target.Length; i++)
        {
            // Trigger the shooting animation
            animator.SetTrigger("Shoot");
            gun.SetActive(true);

            // Instantiate the projectile at the shoot point
            GameObject projectile = Instantiate(projectiles[currentProjectile], shootPoint.position, Quaternion.identity);

            // Start the coroutine to move the projectile to the target position
            StartCoroutine(MoveProjectile(projectile, target[i].position));
        }
        
    }
    private IEnumerator MoveProjectile(GameObject projectile, Vector3 targetPosition)
    {
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        // Disable gravity and other physics interactions while moving
        if (rb != null)
        {
            rb.isKinematic = true;
        }

        while (Vector3.Distance(projectile.transform.position, targetPosition) > 0.1f)
        {
            // Calculate the step size based on shootSpeed and deltaTime
            float step = shootspeed * Time.deltaTime;
            projectile.transform.position = Vector3.MoveTowards(projectile.transform.position, targetPosition, step);

            yield return null; // Wait until the next frame
        }

        // Ensure the projectile is exactly at the target position
        projectile.transform.position = targetPosition;

        // Re-enable physics if needed
        if (rb != null)
        {
            rb.isKinematic = false;
        }
    }
    public void SwitchProjectile(int i)
    {
        currentProjectile = (i) % projectiles.Length;
    }
}