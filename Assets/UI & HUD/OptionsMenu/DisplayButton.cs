using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayButton : MonoBehaviour
{
    public GameObject displayOptions;
    public GameObject audioOptions;
    public TMP_Dropdown displaymode;
    public TMP_Dropdown resolution;

    public void DisplayClick()
    {
        displayOptions.SetActive(true);
        audioOptions.SetActive(false);
    }


    public void UpdateDisplay()
    {
        if(displaymode.value == 0)
        {
            Screen.fullScreen = true;
        }
        else if(displaymode.value == 1)
        {
            Screen.fullScreen = false;
        }
    }


    public void UpdateResolution()
    {
        Debug.Log(displaymode.value);
        if(displaymode.value == 0)
        {
            Screen.SetResolution(1280, 720, Screen.fullScreen);
        }
        else if(displaymode.value == 1)
        {
            Screen.SetResolution(1920, 1080, Screen.fullScreen);
        }
        else if (displaymode.value == 2)
        {
            Screen.SetResolution(2560, 1440, Screen.fullScreen);
        }
        else if (displaymode.value == 3)
        {
            Screen.SetResolution(3840, 2160, Screen.fullScreen);
        }
    }


}
