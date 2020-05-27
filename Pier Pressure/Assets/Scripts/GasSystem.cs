using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GasSystem : MonoBehaviour
{
    public float Timer = 30.0f; 
    private Text gasText;
    GameObject[] ObjWithTag;
    // Start is called before the first frame update
    void Start()
    {
        ObjWithTag = GameObject.FindGameObjectsWithTag("Gas");
        gasText = ObjWithTag[0].GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime; 
        gasText.text = " " + (int)Timer; 

        if(Timer > 30.0f)
        {
            Timer = 30.0f;   
		}
        if(Timer <= 0)
        {
            SceneManager.LoadScene("End Screen");  
		}
    }
    //gas can object interaction 
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag.Equals ("GasCan"))
        {
            Timer += 15.0f; 
            col.gameObject.SetActive(false);
		}
	}
}
