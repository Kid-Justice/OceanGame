using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScore : MonoBehaviour
{
    private Text scoreText; 
    int score; 
    // Start is called before the first frame update
    void Start()
    {
         score = PlayerPrefs.GetInt("score", 100);
         
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
