using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMusicScipt : MonoBehaviour
{
    int i = 0; 
    string sceneName; 
    GameObject[] SoundObject; 
    // Start is called before the first frame update
    void Start()
    {
       
        DontDestroyOnLoad(this.gameObject);   

    }

    // Update is called once per frame
    void Update()
    {
        SoundObject = GameObject.FindGameObjectsWithTag("MMusic"); 
    
        Scene currentScene = SceneManager.GetActiveScene ();
        string sceneName = currentScene.name;

        if(sceneName == "Game")
        {
              Destroy(this.gameObject); 
		}
        if(SoundObject.Length > 1)
        {
            for(int z = 1; z < SoundObject.Length; z++)
            {
                Destroy(SoundObject[i]);
			}
		}
    }
}
