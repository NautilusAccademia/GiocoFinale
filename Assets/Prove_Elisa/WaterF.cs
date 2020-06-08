using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterF : InteractableObjects
{
    [SerializeField] Conditions condition;

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

        if (other.gameObject.CompareTag("Player") && condition.CheckCondition() && Input.GetKeyDown(KeyCode.E))
        {
            ShootingElements.instance.ShootingAir();
            blendShape += 25f;


            // for (blendShape = 0f; blendShape <= 25f; blendShape++) ;


        }
    }

    public override void SpecificInteraction()
    {
        ShootingElements.instance.ShootingAir();
        base.SpecificInteraction();
    }
}
