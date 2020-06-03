using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int healthBar = 3;
    public int MaxHealth = 3;
    GameObject[] ObjWithTag;
    //audio
    public GameObject DamageSound;
    public float spawnTimer = 0f;
    //mine slow down effect
    float slowDown = 5f; 
    float slowDownTimer = 0f; 
    float slowedMaxVelocity = 0.2f; 
    float MaxVelocity = 1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //audio
        if (spawnTimer > 0f)
        {
            spawnTimer -= Time.deltaTime;
        }
        if(healthBar == 0)
        {
            SceneManager.LoadScene("End Screen");        
		}
        if(slowDownTimer >= slowDown)
        {
            PlayerPrefs.SetFloat("MVelocity", MaxVelocity);   
		}
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag.Equals("Mine"))
        {
            healthBar -= 1;
            PlayerPrefs.SetInt("health", healthBar);

            //mine slow down effect
            PlayerPrefs.SetFloat("MVelocity", slowedMaxVelocity);  
            slowDownTimer += Time.deltaTime; 

            //audio
            if (spawnTimer <= 0f)
            {
                Instantiate(DamageSound, transform.position, Quaternion.identity);
                spawnTimer = 2f;
            }
		}
        
    }
}
