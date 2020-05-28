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
    //audio
    public GameObject DamageSound;
    public float spawnTimer = 0f;
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
        //audio
        if (spawnTimer > 0f)
        {
            spawnTimer -= Time.deltaTime;
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag.Equals("Mine"))
        {
            healthBar -= 1;
            PlayerPrefs.SetInt("health", healthBar);
            //audio
            if (spawnTimer <= 0f)
            {
                Instantiate(DamageSound, transform.position, Quaternion.identity);
                spawnTimer = 2f;
            }
		}
        if(healthBar == 0)
        {
            SceneManager.LoadScene("End Screen");        
		}
    }
}
