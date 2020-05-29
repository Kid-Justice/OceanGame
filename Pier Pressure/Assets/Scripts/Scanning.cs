using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scanning : MonoBehaviour
{
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
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag.Equals ("POI"))
        {
              
		}
	}
}
