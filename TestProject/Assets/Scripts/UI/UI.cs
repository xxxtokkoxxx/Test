using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{   
    public void LoadScene(int sceneNumb)
    {
        SceneManager.LoadScene(sceneNumb);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Pause()
    { 
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
    }

    public void Resume()
    {
        if (Time.timeScale != 1)
        {
            Time.timeScale = 1;
        }
    }
}
