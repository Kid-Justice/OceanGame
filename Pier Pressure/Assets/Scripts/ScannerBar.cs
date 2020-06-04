using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScannerBar : MonoBehaviour
{
    public GameObject player;
    Scanning scanning;
    // Start is called before the first frame update
    void Start()
    {
        scanning = player.GetComponent<Scanning>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(scanning.visualTimer / 4f, transform.localScale.y, transform.localScale.z);
    }
}
