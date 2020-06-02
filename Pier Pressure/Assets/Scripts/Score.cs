using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private Text scoreText;
    GameObject[] ObjWithTag;
    public int points = 0;
    //audio
    public GameObject TreasureSound; 
    public float spawnTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        //scoreText = GameObject.FindObjectOfType<Text>();
        ObjWithTag = GameObject.FindGameObjectsWithTag("Score");
        scoreText = ObjWithTag[0].GetComponent<Text>();
        points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("score", points);
        scoreText.text = " " + points; 
        //audio
        if (spawnTimer > 0f)
        {
            spawnTimer -= Time.deltaTime;
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag.Equals ("Treasure"))
        {
              points += 1;
              col.gameObject.SetActive(false);

              //PlayerPrefs.SetInt("score", points);
              //audio
              if (spawnTimer <= 0f)
              {
                  Instantiate(TreasureSound, transform.position, Quaternion.identity);
                  spawnTimer = 2f;
              }
		}
        if(col.gameObject.tag.Equals ("scanTreasure"))
        {
              points += 5;
              col.gameObject.SetActive(false);

              //PlayerPrefs.SetInt("score", points);
              //audio
              if (spawnTimer <= 0f)
              {
                  Instantiate(TreasureSound, transform.position, Quaternion.identity);
                  spawnTimer = 2f;
              }  
		}

	}
}
