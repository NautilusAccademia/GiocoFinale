using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water3 : MonoBehaviour
{
    //[SerializeField] Conditions condition;

    // public GameObject water;
    public Animator waterAn;
    //SkinnedMeshRenderer skinnedMeshRenderer;
    //Mesh skinnedMesh;
    [SerializeField] Collider[] collider;


    void Start()
    {
        collider[0].enabled = true;
        collider[1].enabled = false;
        collider[2].enabled = false;
        collider[3].enabled = false;

        /*skinnedMeshRenderer = water.GetComponent<SkinnedMeshRenderer>();
        skinnedMesh = water.GetComponent<SkinnedMeshRenderer>().sharedMesh;
        skinnedMeshRenderer.SetBlendShapeWeight(0, 0f);*/

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Air"))
        {
            waterAn.SetTrigger("three");
            collider[3].enabled = true;
            collider[2].enabled = false;
        }


    }
}
