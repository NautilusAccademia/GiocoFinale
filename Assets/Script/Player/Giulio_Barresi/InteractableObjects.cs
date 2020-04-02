using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableObjects : MonoBehaviour
{
    public void Interact()
    {
        SpecificInteraction();
    }

    public virtual void SpecificInteraction()
    {
        
    }

    protected void OnTriggerEnter(Collider other)
    {
        GameManager.instance.interactableObjectsList.Add(this);
        if (other.CompareTag("Player"))
        {
            HUD.instance.infoEImage.enabled = true;
        }
    }

    protected void OnTriggerExit(Collider other)
    {
        GameManager.instance.interactableObjectsList.Remove(this);
        HUD.instance.infoEImage.enabled = false;
    }
}
