﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BegoniaPlayerMovement : MonoBehaviour
{
    public static BegoniaPlayerMovement instance { get; private set; }
    public string scenePassword;
   
    
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }


    //public BegoniaVectorValue startingPosition;

    // Start is called before the first frame update
    //void Start()
    // {
    //    transform.position = startingPosition.initialValue;  
    //}

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Trigger");
    }
}
