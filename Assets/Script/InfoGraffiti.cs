using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InfoGraffiti : MonoBehaviour
{
    //[SerializeField] private Image customImage;
    private void Start()
    {
        HUD.instance.infoZImage.enabled = false;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HUD.instance.infoZImage.enabled = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        HUD.instance.infoZImage.enabled = false;
    }
}
