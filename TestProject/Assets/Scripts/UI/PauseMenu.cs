using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject resume, quit, pause;
    public bool pauseMenu;

    private void Update()
    {
        if (Time.timeScale == 0)
        {
            pauseMenu = true;
            if (pauseMenu == true)
            {
                resume.SetActive(true);
                quit.SetActive(true);
                pause.SetActive(false);
            }
        }

        if (Time.timeScale == 1)
        {
            pauseMenu = false;
            if (pauseMenu == false)
            {
                resume.SetActive(false);
                quit.SetActive(false);
                pause.SetActive(true);
            }
        }
    }
}
