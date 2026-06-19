using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings_Script : MonoBehaviour
{
    public GameObject Setting_Canvas;
    public GameObject Main_Menu_Canvas;
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            OpenSettingPanel();
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            Backtomainmenu();
        }
    }

    public void OpenSettingPanel()
    {
        Setting_Canvas.SetActive(true);
        Main_Menu_Canvas.SetActive(false);
       
    }

    public void Backtomainmenu()
    {
        Setting_Canvas.SetActive(false);
        Main_Menu_Canvas.SetActive(true);
        
    }
}
