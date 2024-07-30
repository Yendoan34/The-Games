using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class castleDoor : MonoBehaviour
{
    public int enemiesWin = 0;

    void OnTriggerEnter2D(Collider2D  other)
    {
        if (other.tag == "Enemy")
        {
            enemiesWin++;
        }
    }
}
