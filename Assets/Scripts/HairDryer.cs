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
            rb = hit.collider.GetComponent<Rigidbody2D>();
            Debug.Log(rb.velocity);
            rb.AddForce(transform.right * thrust, ForceMode2D.Impulse);
            timer += Time.deltaTime;
            Debug.Log(timer);
        }
        if (timer >= 4f)
        {
            rb.velocity = new Vector2(0.0f, 0.0f);
            rb.angularVelocity = 0f;
        }
    }
}
