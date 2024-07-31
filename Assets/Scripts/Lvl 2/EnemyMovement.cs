using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float moveSpeed = 2f;

    Transform target;
    GameObject castle;
    int pathIndex = 0;
    int increase = 1;

    void Start()
    {
        target = LevelManager.main.path[pathIndex];
        castle = GameObject.Find("Castle Door");
    }

    void Update()
    {
        if (Vector2.Distance(target.position, transform.position) <= 0.1f)
        {
            pathIndex++;


            if (pathIndex == LevelManager.main.path.Length)
            {
                EnemySpawner.onEnemyDestroy.Invoke();
                castle.gameObject.GetComponent<castleDoor>().Counter(increase);
                Destroy(gameObject);
                return;
            }
            else 
            {
                target = LevelManager.main.path[pathIndex];
            }
        }
    }

    void FixedUpdate()
    {
        Vector2 direction = (target.position - transform.position).normalized;
        rb.velocity = direction * moveSpeed;
    }
}
