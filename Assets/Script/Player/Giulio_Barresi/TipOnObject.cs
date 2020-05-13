using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipOnObject : MonoBehaviour
{
    //Nanni
    [SerializeField]
    Material mat;//The material

    [SerializeField]
    bool isGlowing;//Boolean that tells if the mesh is glowing or not

    private void Start()//As the game starts...
    {
        mat = GetComponent<Renderer>().material;//Take the material from the renderer component
        mat.DisableKeyword("_EMISSION");//Disable the emission
        isGlowing = false;//and tell that the mesh is not glowing
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))//If the player is passing by...
        {
            mat.EnableKeyword("_EMISSION");//enable the emission
            isGlowing = true;//And tell that the mesh is glowing
        }
    }

    private void OnTriggerExit(Collider other)//But if the player is not close...
    {
        mat.DisableKeyword("_EMISSION");//Disable the emission
        isGlowing = false;//And tell that the mesh is not glowing
    }



    /*
    //Giulio
    [SerializeField]
    GameObject ParticleTip;

    // Start is called before the first frame update
    void Start()
    {
        ParticleTip.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ParticleTip.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ParticleTip.SetActive(false);
    }
    */
}
