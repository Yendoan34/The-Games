using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int shootSpeed = 10;
    public GameObject gun;
    public GameObject[] projectiles; // Array to hold different projectiles
    public Transform shootPoint;
    public Transform[] targets;
    private int currentProjectile = 0; // Index to keep track of current projectile type
    private Animator animator; // Reference to the Animator component

    private bool isShooting = false; // Flag to track if shoot method is activated

    void Start()
    {
        animator = GetComponent<Animator>(); // Get the Animator component
    }

    void Update()
    {
        if (isShooting && Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0; // Set z to 0 since we're in 2D

            float closestDistance = float.MaxValue;
            Transform closestTarget = null;

            // Find the closest target to the mouse position
            foreach (Transform target in targets)
            {
                float distance = Vector3.Distance(mousePosition, target.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestTarget = target;
                }
            }

            // Check if the closest target is within a reasonable range (e.g., 0.5 units)
            if (closestTarget != null && closestDistance <= 0.55f)
            {
                ShootAtTarget(closestTarget);
            }

            // Reset the shooting flag
            isShooting = false;
        }
    }

    public void Shoot()
    {
        // Set the flag to true when Shoot method is called
        isShooting = true;
    }

    private void ShootAtTarget(Transform target)
    {
        AudioManager.instance.PlaySound("Shoot");
        // Trigger the shooting animation
        animator.SetTrigger("Shoot");
        gun.SetActive(true);

        // Instantiate the projectile at the shoot point
        GameObject projectile = Instantiate(projectiles[currentProjectile], shootPoint.position, Quaternion.identity);

        // Start the coroutine to move the projectile to the target position
        StartCoroutine(MoveProjectile(projectile, target.position));
    }

    private IEnumerator MoveProjectile(GameObject projectile, Vector3 targetPosition)
    {
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        Vector3 initialScale = projectile.transform.localScale; // Store the initial scale of the projectile
        Vector3 targetScale = initialScale * 2; // The target scale is double the initial scale

        // Disable gravity and other physics interactions while moving
        if (rb != null)
        {
            rb.isKinematic = true;
        }

        while (Vector3.Distance(projectile.transform.position, targetPosition) > 0.1f)
        {
            // Calculate the step size based on shootSpeed and deltaTime
            float step = shootSpeed * Time.deltaTime;
            projectile.transform.position = Vector3.MoveTowards(projectile.transform.position, targetPosition, step);

            // Calculate the scaling step based on the distance to the target
            float distanceToTarget = Vector3.Distance(projectile.transform.position, targetPosition);
            float totalDistance = Vector3.Distance(shootPoint.position, targetPosition);
            float scaleProgress = 1 - (distanceToTarget / totalDistance);
            projectile.transform.localScale = Vector3.Lerp(initialScale, targetScale, scaleProgress);

            yield return null; // Wait until the next frame
        }

        // Ensure the projectile is exactly at the target position and has the target scale
        projectile.transform.position = targetPosition;
        projectile.transform.localScale = targetScale;

        // Re-enable physics if needed
        if (rb != null)
        {
            rb.isKinematic = false;
        }
    }

    public void SwitchProjectile(int i)
    {
        currentProjectile = i % projectiles.Length;
    }
}
