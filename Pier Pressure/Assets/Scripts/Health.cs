using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int healthBar = 3; 
    private Text healthText;
    // Start is called before the first frame update
    void Start()
    {
         healthText = GameObject.FindObjectOfType<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = " " + healthBar; 
    }
      private void OnTriggerEnter2D(Collider2D col)
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
