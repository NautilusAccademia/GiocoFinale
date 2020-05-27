using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoFire : MonoBehaviour
{
    [SerializeField] GameObject FireIsOnBrazier;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !FireIsOnBrazier.activeInHierarchy && !InteractiveElement.instance.ElementInstantiated[0].activeInHierarchy)
        {
            HUD.instance.infoFireEimage.enabled = true;
            
        }
        if (FireIsOnBrazier.activeInHierarchy || InteractiveElement.instance.ElementInstantiated[0].activeInHierarchy)
        {
            HUD.instance.infoEImage.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        HUD.instance.infoFireEimage.enabled = false;
        HUD.instance.infoEImage.enabled = false;
    }
}
