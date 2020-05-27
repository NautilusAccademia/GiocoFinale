using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoE : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            HUD.instance.infoEImage.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        HUD.instance.infoEImage.enabled = false;
    }
}
