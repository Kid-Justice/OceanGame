using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poiExpire : MonoBehaviour
{
    float scanTimer; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.GetFloat("scanTimer", 0f); 
        if(scanTimer > 0f)
        {
            scanTimer -= Time.deltaTime;
		}
        if(scanTimer < 1f)
        {
            Destroy(gameObject);   
		}
    }
}
