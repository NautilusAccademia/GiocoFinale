using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoEarth : MonoBehaviour
{
    [SerializeField] GameObject EarthIsActive;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !EarthIsActive.activeInHierarchy && !InteractiveElement.instance.ElementInstantiated[3].activeInHierarchy)
        {
            HUD.instance.infoEarthEimage.enabled = true;

        }
        if (EarthIsActive.activeInHierarchy || InteractiveElement.instance.ElementInstantiated[3].activeInHierarchy)
        {
            HUD.instance.infoEImage.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        HUD.instance.infoEarthEimage.enabled = false;
        HUD.instance.infoEImage.enabled = false;
    }
}
