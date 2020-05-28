using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landmine : MonoBehaviour
{
    public int damage = 10;
    public GameObject ExplosionEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Health>() != null)
        {
            collision.GetComponent<Health>().healthBar -= damage;
            GameObject Explode = Instantiate(ExplosionEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
