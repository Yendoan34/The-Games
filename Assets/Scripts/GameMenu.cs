using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.SceneManagement;


// Open a specific scene
public class GameMenu : MonoBehaviour

{

    void Start()
    {
        
    }

    public void OpenScene(int i)

    {

        SceneManager.LoadScene(i);

    }

}