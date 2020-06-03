using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poiExpire : MonoBehaviour
{
    public GameObject player;   
    int distance = 100;      

    public GameObject scanTreasure; 
    float scanTimer = 0f; 
    float timeTillScan = 5f;
    //audio
    public GameObject SonarSound; 
    public float spawnTimer = 0f;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player"); 
        //pOI = GameObject.FindGameObjectsWithTag("POI");
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.GetFloat("scanTimer", 0f); 
        scanTimer = PlayerPrefs.GetFloat("scanTimer"); 

        if(scanTimer >= timeTillScan)
        {
            Instantiate(scanTreasure, transform.position, Quaternion.identity);  
            PlayerPrefs.SetFloat("scanTimer", 0f);
            Destroy(gameObject);   
		}
        //if player is close to POI, play sonar ping SFX at an interval
        if(Vector3.Distance(transform.position, player.transform.position) < distance)
        {
           timer += Time.deltaTime; 
		}
        if(timer >= 3)
        {
            Instantiate(SonarSound, transform.position, Quaternion.identity);   
            timer = 0f; 
		}
    }
  
}
