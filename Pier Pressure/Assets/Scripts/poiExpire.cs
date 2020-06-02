using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poiExpire : MonoBehaviour
{
    public GameObject Treasure; 
    float scanTimer = 0f; 
    float timeTillScan = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.GetFloat("scanTimer", 0f); 
        scanTimer = PlayerPrefs.GetFloat("scanTimer"); 

        if(scanTimer >= timeTillScan)
        {
            Instantiate(Treasure, transform.position, Quaternion.identity);  
            PlayerPrefs.SetFloat("scanTimer", 0f);
            Destroy(gameObject);   
		}
    }
}
