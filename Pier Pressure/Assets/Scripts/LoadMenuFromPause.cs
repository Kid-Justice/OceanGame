using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMenuFromPause : MonoBehaviour
{
    public string SceneName;
    public void LoadScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneName);
    }
}
