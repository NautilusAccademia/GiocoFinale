using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterF : MonoBehaviour
{


    public GameObject water;
    SkinnedMeshRenderer skinnedMeshRenderer;
    Mesh skinnedMesh;
    float blendShape;




    // Start is called before the first frame update
    void Start()
    {
        skinnedMeshRenderer = water.GetComponent<SkinnedMeshRenderer>();
        skinnedMesh = water.GetComponent<SkinnedMeshRenderer>().sharedMesh;
        blendShape = 0;




    }


    void OnTriggerEnter(Collider other)
    {
        skinnedMeshRenderer.SetBlendShapeWeight(0, blendShape);

        if (other.gameObject.CompareTag("Air"))
        {

            blendShape += 25f;


            // for (blendShape = 0f; blendShape <= 25f; blendShape++) ;


        }
    }









    // Update is called once per frame
    void Update()
    {




    }




}
