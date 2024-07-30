using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondKen : MonoBehaviour
{
    float time = 0f;

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
            Destroy(enemy);
        }
    }
}
