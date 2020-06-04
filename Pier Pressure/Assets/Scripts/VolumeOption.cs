using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeOption : MonoBehaviour
{
    public GameObject ExampleSound;
    public GameObject mainCamera;
    public Text text;
    public int volume = 5;
    // Start is called before the first frame update
    void Start()
    {
        volume = PlayerPrefs.GetInt("VolumeID", 5);
    }

    void Update()
    {
        PlayerPrefs.SetInt("VolumeID", volume);
        text.text = "Volume: " + volume;
    }
    public void ChangeVolume()
    {
        if (PlayerPrefs.GetFloat("Volume", 1f) >= 1f)
        {
            PlayerPrefs.SetFloat("Volume", 0f);
            volume = 0;
        }
        else
        {
            PlayerPrefs.SetFloat("Volume", PlayerPrefs.GetFloat("Volume", 0f) + 0.2f);
            volume++;
        }
        Instantiate(ExampleSound, new Vector3(0f, 0f, 0f), Quaternion.identity);
    }
}
