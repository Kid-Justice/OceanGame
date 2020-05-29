using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public GameObject Player;
    Health healthScript;
    float health;
    float maxhealth;
    // Start is called before the first frame update
    void Start()
    {
        healthScript = Player.GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        health = healthScript.healthBar;
        maxhealth = healthScript.MaxHealth;
        Debug.Log(health);
        Debug.Log(health / maxhealth);
        transform.localScale = new Vector3(health/maxhealth, transform.localScale.y, transform.localScale.z);
    }
}
