using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScripts : MonoBehaviour
{
    public GameObject MovingSound; 
    public GameObject DamageSound;
    public GameObject ButtonSelectSound;
    public GameObject MineSound; 
    public GameObject GasCanSound; 
    public GameObject ScanningSound; 
    public GameObject SonarSound;
    public GameObject TreasureSound;
    public GameObject Player;
    public float Timer = 0.0f; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
        if(Timer <= 0.0f)
        {
            Destroy(this.gameObject); 
		}
       
    }
    private void Spawning()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            Instantiate(MovingSound, transform.position, Quaternion.identity);
            Timer += 2.0f; 
		}
        /*
        if(Health.OnTriggerEnter2D())
        {
            Instanciate(DamageSound) as GameObject;   
            Timer += 1.0f; 
		}
        if(GasSystem.OnTriggerEnter2D())
        {
             Instanciate(GasCanSound) as GameObject; 
             Timer += 1.0f; 
		}
        */
	}
}
