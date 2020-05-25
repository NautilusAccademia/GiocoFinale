﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTubes : MonoBehaviour
{
    [SerializeField] Conditions condition;

    [SerializeField] ParticleSystem waterParticle;

    public GameObject water;
    SkinnedMeshRenderer skinnedMeshRenderer;
    Mesh skinnedMesh;

    bool buttonPressed;

    float numWater = 0f;
    private Animator anim;

    void Start()
    {
        buttonPressed = false;
        skinnedMeshRenderer = water.GetComponent<SkinnedMeshRenderer>();
        skinnedMesh = water.GetComponent<SkinnedMeshRenderer>().sharedMesh;
        anim= GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Air") && buttonPressed == false)
        {
            buttonPressed = true;
            waterParticle.Play(true);
            anim.SetTrigger("Pressing");

            //skinnedMeshRenderer.GetBlendShapeWeight(25);// fa alzare livello acqua
        for(int i = 0; i < 4; i++)
        {
            skinnedMeshRenderer.SetBlendShapeWeight(0, (numWater += 25f));
        }
            //skinnedMeshRenderer.SetBlendShapeWeight(0, (numWater += 25f));
        }
        
    }
}
