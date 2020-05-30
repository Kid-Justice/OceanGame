using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scanning : MonoBehaviour
{
    public GameObject Treasure; 
    GameObject[] pOI; 
    public float scanTimer = 0f; 
     
    // Start is called before the first frame update
    void Start()
    {
        pOI = GameObject.FindGameObjectsWithTag("POI");
    }

    // Update is called once per frame
    void Update()
    {
        if (scanTimer > 0f)
        {
            scanTimer -= Time.deltaTime;
        }
        if(scanTimer > 0f && scanTimer < 2f) 
        {
            Instantiate(Treasure, transform.position, Quaternion.identity);  
            PlayerPrefs.SetFloat("scanTimer", scanTimer); 
		}
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag.Equals ("POI"))
        {
            if(Input.GetKeyDown("space"))
            {
                scanTimer += 5f;	
		    }       
		}
    }
}
    