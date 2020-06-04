using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    Scanning scanning;
    public GameObject ScannerBarUI;
    public GameObject PauseMenu;
    public bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        scanning = player.GetComponent<Scanning>();
    }

    // Update is called once per frame
    void Update()
    {
        if (scanning.visualTimer == 0f)
        {
            ScannerBarUI.SetActive(false);
        }
        else
        {
            ScannerBarUI.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }
    public void TogglePause()
    {
        if (isPaused)
        {
            PauseMenu.SetActive(false);
            isPaused = false;
            Time.timeScale = 1f;
        }
        else
        {
            PauseMenu.SetActive(true);
            isPaused = true;
            Time.timeScale = 0f;
        }
    }
}
