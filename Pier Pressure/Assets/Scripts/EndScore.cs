using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScore : MonoBehaviour
{
    private Text scoreText; 
    private Text highScoreText; 
    int currScore = 0; 
    int highScore = 0; 
    GameObject[] ObjWithTag;
    GameObject[] tagObj; 
    // Start is called before the first frame update
    void Start()
    {    
        //score 
        //currScore = PlayerPrefs.GetInt("score", 100);
        ObjWithTag = GameObject.FindGameObjectsWithTag("Score");
        scoreText = ObjWithTag[0].GetComponent<Text>();
       
        //highscore
        tagObj = GameObject.FindGameObjectsWithTag("HighScore");
        highScoreText = tagObj[0].GetComponent<Text>();
    }
    // Update is called once per frame
    void Update()
    {
        currScore = PlayerPrefs.GetInt("score", 100);
        highScore = PlayerPrefs.GetInt("highScore", 0);
        if(currScore > highScore)   
        {
            highScore = currScore;  
            PlayerPrefs.SetInt("highScore", highScore);
		}
        scoreText.text = " " + currScore;
        highScoreText.text = " " + highScore; 
    }
}
