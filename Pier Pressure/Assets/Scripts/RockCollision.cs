using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockCollision : MonoBehaviour
{
    public float spawnTimer = 0f;
    public GameObject CollisionSound; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer > 0f)
        {
            spawnTimer -= Time.deltaTime;
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag.Equals ("Rock"))
        {
            if (spawnTimer <= 0f)
            {
                Instantiate(CollisionSound, transform.position, Quaternion.identity);
                spawnTimer = 2f;
            }  
		}
	}
}
