using Unity.Burst.Intrinsics;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    public float moveSpeed = 5f;
    public int health = 10;
    public int maxHealth = 10;
    public int shootspeed = 10;
    public GameObject[] projectiles; // Array to hold different bubble projectiles
    public Transform shootPoint;
    public float rayLength = 3f; // Length of the ray for visualization
    public GameObject aim;
    private int currentProjectile = 0; // Index to keep track of current projectile type
    public GameObject GameOver;

    private Animator animator; // Reference to the Animator component

    void Start()
    {
        animator = GetComponent<Animator>(); // Get the Animator component
    }

    void Update()
    {
        Move();
        Shoot();
        SwitchProjectile();
    }

    void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        Vector2 move = new Vector2(moveX, moveY).normalized;

        // Calculate the player's next position
        Vector2 nextPosition = (Vector2)transform.position + move * moveSpeed * Time.deltaTime;

        // Clamp the next position to be within the camera's bounds
        float camHeight = Camera.main.orthographicSize;
        float camWidth = camHeight * Camera.main.aspect;
        float minX = Camera.main.transform.position.x - camWidth;
        float maxX = Camera.main.transform.position.x + camWidth;
        float minY = Camera.main.transform.position.y - camHeight;
        float maxY = Camera.main.transform.position.y + camHeight;

        nextPosition.x = Mathf.Clamp(nextPosition.x, minX, maxX);
        nextPosition.y = Mathf.Clamp(nextPosition.y, minY, maxY);

        // Move the player to the clamped position
        transform.position = nextPosition;
    }

    void Shoot()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button click
        {
            // Get the mouse position in world space
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0; // Ensure the z-coordinate is 0

            // Calculate the direction to the mouse position
            Vector3 shootDirection = (mousePosition - shootPoint.position).normalized;

            // Set the shootPoint rotation to face the mouse position
            shootPoint.right = shootDirection;

            // Instantiate the projectile
            GameObject projectile = Instantiate(projectiles[currentProjectile], shootPoint.position, shootPoint.rotation);
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            rb.velocity = shootDirection * shootspeed; // Use the calculated direction for velocity

            // Trigger the shooting animation
            animator.SetTrigger("Shoot");
            AudioManager.instance.PlaySound("Shoot");
        }
    }

    void SwitchProjectile()
    {
        if (Input.GetKeyDown(KeyCode.Q)) // Example key to switch projectiles
        {
            currentProjectile = (currentProjectile + 1) % projectiles.Length;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Destroy the player when it collides with an enemy
            Destroy(gameObject);
            GameOver.SetActive(true);
            aim.SetActive(false);
            Cursor.visible = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            health--;
            if (health <= 0)
            {
                Destroy(gameObject);
                GameOver.SetActive(true);
                aim.SetActive(false);
                Cursor.visible = true;
            }
            Destroy(collision.gameObject);
        }
    }
}