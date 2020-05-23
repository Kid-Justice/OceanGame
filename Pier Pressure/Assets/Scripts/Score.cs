using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private Text scoreText;
    public int points = 0;
    // Start is called before the first frame update
    void Start()
    {
         scoreText = GameObject.FindObjectOfType<Text>();
         
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = " " + points; 
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag.Equals ("Player"))
        {
              points += 1;
              col.gameObject.SetActive(false);

              PlayerPrefs.SetInt("score", points);
		}

	}
}
