using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// When enemy collide with this object, the enemy will pass to the castle
public class Castle : MonoBehaviour
{
    private float enemies = 0;
    public int maxEnemy = 8;
    public GameObject barbie;
    public GameObject fail;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (enemies == maxEnemy)
        {
            barbie.SetActive(false);
            fail.SetActive(true);

        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            enemies++;
            Destroy(collision.gameObject);
        }
    }
}
