using UnityEngine;

public class TestEnemy : MonoBehaviour
{
    public float moveSpeed = 1f;
    public Transform targetPosition;
    public Transform target;
    public Transform castlePosition;
    public bool stop = false;
    private Rigidbody2D rb;

    void Start()
    {
        target = targetPosition;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!stop)
        {
            // Move towards the target position using Rigidbody2D
            Vector2 direction = (target.position - transform.position).normalized;
            rb.velocity = direction * moveSpeed;

            // If close to the target position, set a new target
            if (Vector3.Distance(transform.position, targetPosition.position) < 0.1f)
            {
                SetNewTargetPosition();
            }
        }
        else
        {
            rb.velocity = Vector2.zero; // Ensure the velocity is set to zero when stopped
        }
    }
    public void StopMovement()
    {
        stop = true;
    }
    public void ResumeMovement()
    {
        stop = false;
    }
    void SetNewTargetPosition()
    {
        target = castlePosition;
    }
}
