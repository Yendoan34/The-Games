using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 2f;
    public int health = 3;

    public int maxHealth;
    public Transform targetPosition;
    public Transform target;
    public Transform castlePosition;
    void Start()
    {
        maxHealth = health;
        target = targetPosition;
    }

    void Update()
    {
        // Move towards the target position
        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        // If close to the target position, set a new target
        if (Vector3.Distance(transform.position, targetPosition.position) < 0.1f)
        {
            SetNewTargetPosition();
        }
    }

    void SetNewTargetPosition()
    {
        target = castlePosition;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Respawn"))
        {
            AudioManager.instance.PlaySound("Hit");
            health--;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
            Destroy(collision.gameObject);
        }
    }
}
