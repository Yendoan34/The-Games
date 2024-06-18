using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairDryer : MonoBehaviour
{
    public float range = 100.0f;              // kuinka pitk‰lle ampunin voi tapahtua
    public float damage = 25.0f;              // kuinka paljon damagea tehd‰‰n
    public LayerMask enemyLayer;           // Mihin layeriin pyssy voi vaikuttaa
    public float rayDistance = 10f; // Set the distance for the raycast
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Perform the raycast
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, Vector2.right, rayDistance, enemyLayer);

        // Iterate through the hits and find the first valid hit
        foreach (RaycastHit2D hit in hits)
        {
            // Ignore the self-collider
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.name);
            }
        }
    }
}
