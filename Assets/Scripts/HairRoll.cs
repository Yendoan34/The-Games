using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class HairRoll : MonoBehaviour
{
    public Rigidbody2D body;
    public float speed = 2f;
    private void Start()
    {
        AudioManager.instance.PlaySound("Hair Roll");
    }
    // Update is called once per frame
    void Update()
    {
        body.velocity = Vector2.right * speed;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject.GetComponent<Collider2D>());
            StartCoroutine(DestroyWithDelay(collision.gameObject, 1f));
        }
    }
    IEnumerator DestroyWithDelay(GameObject enemy, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(enemy);
        Destroy(gameObject);
    }
}
