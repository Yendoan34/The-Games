using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondKen : MonoBehaviour
{
    float time = 0f;
    int KenDamage = 6;

    void Start()
    {
        AudioManager.instance.PlaySound("Magic");

        KenThing();
    }

    void Update()
    {
        time += Time.deltaTime;
        // Destroy Ken after 2 seconds
        if (time > 2f)
        {
            Destroy(gameObject);
        }
    }

    void KenThing()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            if (enemy.transform.parent == null || enemy.transform.parent.tag != "Enemy")
            {
                enemy.gameObject.GetComponent<EnemyHealth2>().TakeDamage(KenDamage);
            }
        }
    }
}
