using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class castleDoor : MonoBehaviour
{
    public int enemiesWin = 0;

    void Update()
    {
        if (enemiesWin == 5)
        {
            SceneManager.LoadScene(18);
        }
    }

    public void Counter(int increase)
    {
        enemiesWin = enemiesWin + increase;
    }
}
