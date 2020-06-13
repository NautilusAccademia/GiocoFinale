using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WaterParticles : MonoBehaviour
{
    
    //[SerializeField] GameObject waterGo;

    [SerializeField] ParticleSystem waterPart;

    void Start()
    {
        waterPart.gameObject.SetActive(false);
        //waterGo.SetActive(false);
    }

    public void Tap()
    {
        waterPart.gameObject.SetActive(true);
        waterPart.Play();
        //waterGo.SetActive(true);
        /*if (waterPart.time == 3.00f)
        {
        waterGo.SetActive(false);
        }*/

        //waterPart.gameObject.SetActive(true);
    }
    private void Update()
    {
        if (waterPart.isStopped)
        {
            waterPart.gameObject.SetActive(false);
        }
    }
}


