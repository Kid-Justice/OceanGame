using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expiration : MonoBehaviour
{
    public float TimeTillDestroy = 3.0f;
    float timer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= TimeTillDestroy)
        {
            Destroy(gameObject);
        }
    }
}
