using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int healthBar = 3; 
    private Text healthText;
    GameObject[] ObjWithTag;
    // Start is called before the first frame update
    void Start()
    {
        ObjWithTag = GameObject.FindGameObjectsWithTag("Health");
        healthText = ObjWithTag[0].GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = " " + healthBar; 
    }
      public void OnTriggerEnter2D(Collider2D col)
      {
           if(col.gameObject.tag.Equals("Mine"))
           {
                healthBar -= 1;
                PlayerPrefs.SetInt("health", healthBar);
		   }
           if(healthBar == 0)
           {
                SceneManager.LoadScene("End Screen");        
         
		   }

	  }
}
