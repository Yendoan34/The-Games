using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// When enemy collide with this object, the enemy will pass to the castle
public class Castle : MonoBehaviour
{
    private float enemies = 0;
    public int maxEnemy = 8;
    public GameObject fail;
    private CountEnemy passed;
    // Start is called before the first frame update
    void Start()
    {
        passed = GameObject.Find("Manager").GetComponent<CountEnemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemies == maxEnemy)
        {
            fail.SetActive(true);

        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            enemies++;
            passed.passEnemy++;
            Destroy(collision.gameObject);
        }
    }
}
