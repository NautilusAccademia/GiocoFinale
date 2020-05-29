using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTubes : MonoBehaviour
{
    //[SerializeField] Conditions condition;

    public GameObject water;
    SkinnedMeshRenderer skinnedMeshRenderer;
    Mesh skinnedMesh;

    bool buttonPressed;

    void Start()
    {
        buttonPressed = false;
        skinnedMeshRenderer = water.GetComponent<SkinnedMeshRenderer>();
        skinnedMesh = water.GetComponent<SkinnedMeshRenderer>().sharedMesh;
        skinnedMeshRenderer.SetBlendShapeWeight(0, 0f);
    }
}
