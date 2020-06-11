using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterF : InteractableObjects
{
    public static bool buttonPressed;
    public GameObject tube;
    


    //[SerializeField] Conditions condition;

    //public GameObject water;
    //SkinnedMeshRenderer skinnedMeshRenderer;
    //Mesh skinnedMesh;
    //public float blendShape;

    // Start is called before the first frame update
    /*void Start()
    {
        skinnedMeshRenderer = water.GetComponent<SkinnedMeshRenderer>();
        skinnedMesh = water.GetComponent<SkinnedMeshRenderer>().sharedMesh;
        blendShape = 0;

        skinnedMeshRenderer.SetBlendShapeWeight(0, blendShape);



    }*/

    /*private void Update()
    {
        skinnedMeshRenderer.SetBlendShapeWeight(0, blendShape);
    }*/

    /*void OnTriggerEnter(Collider other)
    {
        //skinnedMeshRenderer.SetBlendShapeWeight(0, blendShape);

        if (other.gameObject.CompareTag("Player") && condition.CheckCondition() && Input.GetKeyDown(KeyCode.E))
        {
            
            
            


            // for (blendShape = 0f; blendShape <= 25f; blendShape++) ;


        }
    }*/


    private void Start()
    {
        buttonPressed = false;
    }
    void FillWater()
    {
        buttonPressed = true;
        /*if (condition.CheckCondition() && Input.GetKeyDown(KeyCode.E))
        {
            
            
        }*/
        ShootingElements.instance.ShootingAir();
        //skinnedMeshRenderer.SetBlendShapeWeight(0, 25f);
        //skinnedMeshRenderer.SetBlendShapeWeight(0, blendShape);

        WaterShape.blendShape += 25f;
      
        //WaterParticles.instance.Tap();

    }

    public override void SpecificInteraction()
    {
        base.SpecificInteraction();
        FillWater();
        ShootingElements.instance.ShootingAir();
    }
}
