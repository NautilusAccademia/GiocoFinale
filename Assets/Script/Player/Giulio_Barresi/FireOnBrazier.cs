using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireOnBrazier : InteractableObjects
{
    [SerializeField]
    public GameObject Fire;

    public override void Initialize()
    {
        Fire.SetActive(false);
    }

    public void SpawnFireOnBrazier()
    {
        Fire.SetActive(true);
        InteractiveElement.instance.DestroyElement();
        HUD.instance.HideFireHUD();
        HUD.instance.infoFireEimage.enabled = false;
    }

    public override void SpecificInteraction()
    {
        base.SpecificInteraction();
        SpawnFireOnBrazier();
    }
}
