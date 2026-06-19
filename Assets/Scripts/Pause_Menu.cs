using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_Menu : MonoBehaviour
{
    public GameObject Pause_Canvas;
    public bool IsPaused = false;

   

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused)
            {
                Resume_Game();
            }
            else
            {
                Pause_Game();
            }
        }
    }

    public void Pause_Game()
    {
        Pause_Canvas.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
    }

    public void Resume_Game()
    {
        Pause_Canvas.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }
}
