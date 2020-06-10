using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterShape : MonoBehaviour
{
    public GameObject water;
    SkinnedMeshRenderer skinnedMeshRenderer;
    Mesh skinnedMesh;
    public static float blendShape;
   

    // Start is called before the first frame update
    void Start()
    {
        skinnedMeshRenderer = water.GetComponent<SkinnedMeshRenderer>();
        skinnedMesh = water.GetComponent<SkinnedMeshRenderer>().sharedMesh;
        blendShape = 0;

        skinnedMeshRenderer.SetBlendShapeWeight(0, blendShape);
    }

    // Update is called once per frame
    void Update()
    {
        skinnedMeshRenderer.SetBlendShapeWeight(0, blendShape);
    }
}
