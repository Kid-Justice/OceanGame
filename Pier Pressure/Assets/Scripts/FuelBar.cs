using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelBar : MonoBehaviour
{
    public GameObject Player;
    GasSystem FuelScript;
    // Start is called before the first frame update
    void Start()
    {
        FuelScript = Player.GetComponent<GasSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(FuelScript.Timer / FuelScript.MaxTimer, transform.localScale.y, transform.localScale.z);
    }
}
