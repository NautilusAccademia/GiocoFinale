using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetObjectsInteraction : InteractableObjects
{
    [SerializeField] GameObject[] objectsToActive;
    [SerializeField] GameObject[] objectsToDeactive;

    public override void SpecificInteraction()
    {
        base.SpecificInteraction();
        SetObjects();
    }

    void SetObjects()
    {
        foreach (GameObject gameObject in objectsToActive)
        {
            gameObject.SetActive(true);
        }
        foreach (GameObject gameObject in objectsToDeactive)
        {
            gameObject.SetActive(false);
        }
    }
}
