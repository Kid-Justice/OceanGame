﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip MovingSFX; 
    static AudioSource audioSource;  



    // Start is called before the first frame update
    void Start()
    {
        MovingSFX = Audio.Load<AudioClip>("MovingSFX");
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void MoveSound()
    {
        audioSource.PlayOneShot(MovingSFX);
	}
}
