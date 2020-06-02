using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scanning : MonoBehaviour
{
    GameObject[] pOI; 
    float scanTimer = 0f; 
    float timeTillScan = 5f; 
    // Start is called before the first frame update
    void Start()
    {
        pOI = GameObject.FindGameObjectsWithTag("POI");
        PlayerPrefs.SetFloat("scanTimer", 0f); 
    }

    // Update is called once per frame
    void Update()
    {
        if (scanTimer < timeTillScan && scanTimer > 0f)
        {
            scanTimer += Time.deltaTime;
        }
        if(scanTimer >= timeTillScan) 
        {
            PlayerPrefs.SetFloat("scanTimer", scanTimer); 
		}
        PlayerPrefs.GetFloat("scanTimer", 0f); 
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag.Equals ("POI"))
        { 
            if(Input.GetKey(KeyCode.F))  
            {
                scanTimer += 1f;        
			}
		}
    }
}
    