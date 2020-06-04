using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fullscreen : MonoBehaviour
{
    public Text text;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Screen.fullScreen)
        {
            text.text = "Fullscreen: ON";
        }
        else 
        {
            text.text = "Fullscreen: OFF";
        }
    }
    public void ToggleFullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
}
