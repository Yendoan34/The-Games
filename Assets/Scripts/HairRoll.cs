using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;

public class HairRoll : MonoBehaviour
{
    public Rigidbody2D body;
    public float speed = 2f;
    public GameObject star;
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
            StartCoroutine(DestroyWithDelay(collision.transform.parent.gameObject, 1f));
        }
    }
    IEnumerator DestroyWithDelay(GameObject enemy, float delay)
    {
        yield return new WaitForSeconds(delay);
        AudioManager.instance.PlaySound("Magic");
        Vector3 targetPosition = transform.position + new Vector3(0, 2, 0);
        GameObject point = Instantiate(star, targetPosition, Quaternion.identity);
        Destroy(enemy);
        Destroy(gameObject);
    }
}
