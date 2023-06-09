﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardUI : MonoBehaviour
{
    private SoundHandler soundhandler;
    public bool keyHit = false;
    public bool keyCanBeHitAgain = false;

    private float originalYPosition;
    void Start()
    {
        soundhandler = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundHandler>();
        originalYPosition = transform.position.y;
    }

    void Update()
    {
        if(keyHit)
        {
            soundhandler.PlayClickSound();
            keyCanBeHitAgain = false;
            keyHit = false;
            transform.position += new Vector3(0, -0.03f, 0);

        }
        if(transform.position.y < originalYPosition)
        {
            transform.position += new Vector3(0, 0.005f, 0);
        } else
        {
            keyCanBeHitAgain = true;
        }
    }
}
