using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TutorialUI : MonoBehaviour
{
    [SerializeField] private Image customImage;
    [SerializeField] private Image Tutorial;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {


            customImage.enabled = true;
        

        }



    }

    void OnTriggerStay (Collider other)
    {

        if ((Input.GetKeyDown(KeyCode.F)))
        {
            Tutorial.enabled = true;
            customImage.enabled = false;


        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            customImage.enabled = false;
            Tutorial.enabled = false;
        }
    }



}  
  
