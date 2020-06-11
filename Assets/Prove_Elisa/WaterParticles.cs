﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WaterParticles : MonoBehaviour
{
    

    public static WaterParticles instance;
    public GameObject waterGo;
    public ParticleSystem waterPart;


    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
       
    }


    void Start()
    {
       waterGo.SetActive(false);
        
    }

  public void Tap()
    {
        if (WaterF.buttonPressed == true)
        {
            waterGo.SetActive(true);
            waterPart.Play();
        }
        /*if (waterPart.time == 3.00f)
        {
            waterGo.SetActive(false);
        }*/
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      
    }
}
