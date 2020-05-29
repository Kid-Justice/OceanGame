using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GasSystem : MonoBehaviour
{
    public float Timer = 30.0f;
    public float MaxTimer = 30.0f;
    GameObject[] ObjWithTag;
    //audio 
    public GameObject GasCanSound; 
    public float spawnTimer = 0f; 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime; 

        if(Timer > 30.0f)
        {
            Timer = MaxTimer;   
		}
        if(Timer <= 0)
        {
            SceneManager.LoadScene("End Screen");  
		}
        //audio
        if (spawnTimer > 0f)
        {
            spawnTimer -= Time.deltaTime;
        }
    }
    //gas can object interaction 
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag.Equals ("GasCan"))
        {
            Timer += 15.0f; 
            col.gameObject.SetActive(false);
            //audio
            if (spawnTimer <= 0f)
            {
                Instantiate(GasCanSound, transform.position, Quaternion.identity);
                spawnTimer = 2f;
            }
		}
	}
}
